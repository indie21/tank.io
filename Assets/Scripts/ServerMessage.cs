using System.IO;
using System;
using UnityEngine;
using proto.packet;
using System.Net.Sockets;
using System.Threading;


public enum SocketState {
    Closed = 1,
    Connected = 2,
    TryConnected = 3
};


public class ServerMessage
{
    const int BUFF_SIZE =  65535;
    const int HEAD_SIZE =  4;

    private Socket clientSocket;
    private readonly ByteBuf buf = new ByteBuf(BUFF_SIZE);
    private SocketState status = SocketState.Closed;

    // public SSocket _netSocket;

    // singleton
    private volatile static ServerMessage _instance;
    private static readonly object lockHelper = new object();

    public ServerMessage() {
        _instance = null;
    }

    public static ServerMessage Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        _instance = new ServerMessage();
                    }
                }
            }
            return _instance;
        }
    }

    // 将数据打包成2进制
    public void Send<T>(int cmd, T message) where T : ProtoBuf.IExtensible {
        byte[] data;
        var ms1 = new MemoryStream();
        var ms2 = new MemoryStream();
        ProtoBuf.Serializer.Serialize<T>(ms1, message);

        var pack = new packet();
        pack.cmd = cmd;
        pack.payload = ms1.ToArray();

        ProtoBuf.Serializer.Serialize<packet>(ms2, pack);
        data = ms2.ToArray();

        if (status == SocketState.Closed) {
            return;
        }

        ByteBuf buf = new ByteBuf(data.Length+4);
        buf.WriteInt(data.Length);
        buf.WriteBytes(data);

        Debug.Log("send:"+data.Length);
        clientSocket.BeginSend(buf.GetRaw(), 0, buf.GetRaw().Length,
                               SocketFlags.None,
                               null, clientSocket);

    }

    public void Connect(string ip, int port) {

        if(status != SocketState.Closed) {
            return;
        }

        status = SocketState.TryConnected;
        clientSocket = new Socket(AddressFamily.InterNetwork,
                                  SocketType.Stream,
                                  ProtocolType.Tcp);

        clientSocket.NoDelay = true;
        var linger = new LingerOption(false, 0);
        clientSocket.LingerState = linger;
        clientSocket.BeginConnect(ip, port, connected_cb, this);
    }

    //连接成功回调
    private void connected_cb(IAsyncResult ar) {

        clientSocket.EndConnect(ar);
        if (!clientSocket.Connected){
            return;
        }

        status = SocketState.Connected;

        var thread = new Thread(new ThreadStart(waitSocket));
        thread.IsBackground = true;
        thread.Start();
    }

    // 异步收包线程.
    private void waitSocket() {
        Debug.Log("receiver");
        int len;

        while(true)
        {
            if (!clientSocket.Poll(-1, SelectMode.SelectRead))
            {
                Debug.Log("poll error");
                Close();
            }

            len = clientSocket.Receive(buf.GetRaw(), 0, HEAD_SIZE,
                                       SocketFlags.None);

            Debug.Log("receive length:"+ len);

            if(len<0)
            {
                Debug.Log("length error");
                Close();
                return;
            }

            Debug.Assert(len == HEAD_SIZE);
            int payload_length = buf.GetInt(0);

            Debug.Assert(payload_length < BUFF_SIZE);

            len = clientSocket.Receive(buf.GetRaw(), 0, payload_length,
                                       SocketFlags.None);

            Debug.Log("receive length:" + len);

            Debug.Assert(payload_length == len);
            string data = BitConverter.ToString(buf.GetRaw(), 0,
                                                payload_length);
            Debug.Log("receiver:" + data);
        }
    }


    // 关闭Socket
    public void Close() {
        if (clientSocket != null && clientSocket.Connected) {
            clientSocket.Shutdown(SocketShutdown.Both);
        }
        clientSocket.Close();
    }




};
