using proto.packet;
using proto.payload;
using UnityEngine;
using System.IO;
using System.Net.Sockets;

public class ModRoom {

    public void RegisterEvent() {
        Event.RegisterIn("room_join_req", this, "JoinReq");
        Event.RegisterOut("room_join_ack", this, "JoinAck");
    }


    public void JoinReq() {
        var roomJoinReq = new room_join_req();
        roomJoinReq.player_id = GameManager._userId;
        roomJoinReq.name = System.Text.Encoding.Default.GetBytes("good");
        ServerMessage.Instance.Send<room_join_req>(1003, roomJoinReq);
    }

    public void JoinAck(byte[] ackBin) {
        var ms2 = new MemoryStream(ackBin, 0, ackBin.Length);
        var RoomJonAck = ProtoBuf.Serializer.Deserialize<room_join_ack>(ms2);
        Debug.Log("room join ack");
    }

}
