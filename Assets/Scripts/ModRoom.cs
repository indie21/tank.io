using proto.packet;
using proto.payload;
using UnityEngine;
using System.IO;
using System.Net.Sockets;

public class ModRoom  : MonoBehaviour {
    public Transform _transform;

    private Transform boxHolder;
    private Transform playerHolder;

    public void RegisterEvent() {
        Event.RegisterIn("room_join_req", this, "JoinReq");
        Event.RegisterIn("room_move_req", this, "MoveReq");
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

        GameObject prefeb;
        GameObject go;

        var playerPrefeb = Resources.Load("player",typeof(GameObject)) as GameObject;
        var box1Prefeb = Resources.Load("box1",typeof(GameObject)) as GameObject;
        var box2Prefeb = Resources.Load("box2",typeof(GameObject)) as GameObject;
        var box3Prefeb = Resources.Load("box3",typeof(GameObject)) as GameObject;

        var BoxArray = new GameObject[]{box1Prefeb, box2Prefeb, box3Prefeb};

        // 实例化box
        foreach(var box in RoomJonAck.boxs) {
            prefeb = BoxArray[box.type-1];
            // Debug.Log("prefeb:"+prefeb+ "box:" + box.type);
            var pos = box.trans.position;
            var move = box.trans.position;
            go = GameObject.Instantiate(prefeb,
                                        new Vector3 (pos.x, pos.y, 0),
                                        Quaternion.identity) as GameObject;
            var moveMent = new Vector3(move.x, move.y, move.z);
            go.GetComponent<Box>().SendMessage("SetMove", moveMent);
            go.GetComponent<Box>().SendMessage("SetSpeed", box.trans.speed);
            // go.GetComponent<Transform>().SendMessage("SetParent", boxHolder);
        }

        // 实例化player
        foreach(var player in RoomJonAck.players) {
            var pos = player.trans.position;
            go = GameObject.Instantiate(playerPrefeb,
                                        new Vector3 (pos.x, pos.y, 0),
                                        Quaternion.identity) as GameObject;
            go.transform.SetParent(boxHolder);
            go.GetComponent<Player>().SendMessage("SetPlayerId", player.player_id);

            if (player.player_id== GameManager._userId) {
                var follow = GameObject.FindGameObjectWithTag("MainCamera").
                    GetComponent<Follow>();
                follow._player = go.transform;
                follow._playerObj = go;
            }
        }
    }

    public void MoveReq(proto.payload.transform trans) {
        Debug.Log("moveReq");

        var roomMoveReq = new room_move_req();
        roomMoveReq.player_id = GameManager._userId;
        roomMoveReq.trans = trans;
        ServerMessage.Instance.Send<room_move_req>(1009, roomMoveReq);

    }

    void Awake () {
        boxHolder = new GameObject("boxHolder").transform;
        playerHolder = new GameObject("playerHolder").transform;
    }

    void Start () {
        _transform = GetComponent<Transform>();
    }

    void Update () {

    }

}
