using proto.packet;
using proto.payload;
using UnityEngine;
using System.IO;
using System.Net.Sockets;

public class ModAgent {

    public void RegisterEvent() {
        Event.RegisterIn("agent_login_req", this, "LoginReq");
        Event.RegisterOut("agent_login_ack", this, "LoginAck");
    }

    public void LoginReq(string name) {
        var agentLogin = new agent_login_req();
        ServerMessage.Instance.Send<agent_login_req>(1001, agentLogin);
    }

    public void LoginAck(byte[] ackBin) {
        var ms2 = new MemoryStream(ackBin, 0, ackBin.Length);
        var agentLoginAck = ProtoBuf.Serializer.Deserialize<agent_login_ack>(ms2);
        GameManager._userId = agentLoginAck.player_id;
    }

}
