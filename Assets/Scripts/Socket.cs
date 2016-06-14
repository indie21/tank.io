// http://www.unity.5helpyou.com/3320.html
using System;
using UnityEngine;
//using UnityEngine;
//using System.IO;
//using System.Net;
using System.Net.Sockets;
using System.Threading;
//using System.Diagnostics;

public enum SocketState {
    Closed = 1,
    Connected = 2
};

public class SSocket
{

    const int BUFF_SIZE =  65535;
    const int HEAD_SIZE =  4;

    private Socket clientSocket;
    private readonly ByteBuf buf = new ByteBuf(BUFF_SIZE);
    private SocketState status = SocketState.Closed;

    // 尝试进行连接
    public void Connect(string ip, int port)
    {
        clientSocket = new Socket(AddressFamily.InterNetwork,
                                  SocketType.Stream,
                                  ProtocolType.Tcp);

        clientSocket.NoDelay = true;
        var linger = new LingerOption(false, 0);
        clientSocket.LingerState = linger;
        clientSocket.BeginConnect(ip, port, connected_cb, this);
    }

    //连接成功回调
    private void connected_cb(IAsyncResult ar)
    {
        if (!clientSocket.Connected)
        {
            return;
        }

        clientSocket.EndConnect(ar);
        status = SocketState.Connected;

        var thread = new Thread(new ThreadStart(waitSocket));
        thread.IsBackground = true;
        thread.Start();
    }

    // 关闭Socket
    public void Close()
    {
        if (clientSocket != null && clientSocket.Connected)
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }

    // 发送数据给服务器
    public void Send() {
        if (status == SocketState.Closed) {
            return;
        }
    }

    // 异步收包线程.
    private void waitSocket()
    {
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

            len = clientSocket.Receive(buf.GetRaw(),0, payload_length,
                                       SocketFlags.None);

            Debug.Log("receive length:" + len);

            Debug.Assert(payload_length == len);
            string data = BitConverter.ToString(buf.GetRaw(), 0,
                                                payload_length);
            Debug.Log("receiver:" + data);
        }
    }
}
