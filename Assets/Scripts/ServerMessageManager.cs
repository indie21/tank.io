using UnityEngine;
using System.IO;
using proto.packet;

public class ServerMessageManager
{
    public SSocket NetSocket;


    // singleton
    private volatile static ServerMessageManager _instance;
    private static readonly object lockHelper = new object();

    public ServerMessageManager() {
        _instance = null;
        NetSocket = new SSocket();
    }

    public static ServerMessageManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        _instance = new ServerMessageManager();
                    }
                }
            }
            return _instance;
        }
    }

    public static void Connect(string ip, int port) {
        Instance.NetSocket.Connect(ip, port);
    }

    // 将数据打包成2进制
    public static byte[] Encode<T>(int cmd, T message) where T : ProtoBuf.IExtensible {
        using (var ms1 = new MemoryStream()) {
            ProtoBuf.Serializer.Serialize<T>(ms1, message);

            using(var ms2 = new MemoryStream()) {
                var pack = new packet();
                pack.cmd = cmd;
                pack.payload = ms1.ToArray();

                ProtoBuf.Serializer.Serialize<packet>(ms2, pack);
                return ms2.ToArray();
            }
        }
    }

};
