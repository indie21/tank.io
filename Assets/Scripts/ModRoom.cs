using proto.packet;
using proto.payload;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;

public class ModRoom  : MonoBehaviour {

    static GameObject playerPrefeb;
    static GameObject box1Prefeb;
    static GameObject box2Prefeb;
    static GameObject box3Prefeb;


    public Transform _transform;

    static private GameObject boxHolder;
    static private GameObject playerHolder;

    static private Dictionary<int, GameObject> playerMap =
        new Dictionary<int, GameObject>();
    static private Dictionary<int, GameObject> boxMap =
        new Dictionary<int, GameObject>();

    public void RegisterEvent() {
        Event.RegisterIn("room_join_req", this, "JoinReq");
        Event.RegisterIn("room_move_req", this, "MoveReq");

        Event.RegisterOut("room_join_ack", this, "JoinAck");
        Event.RegisterOut("room_join_ntf", this, "JoinNtf");
        Event.RegisterOut("room_leave_ntf", this, "LeaveNtf");
        Event.RegisterOut("room_move_ntf", this, "MoveNtf");
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
            go.transform.SetParent(boxHolder.transform);
        }

        // 实例化player
        foreach(var player in RoomJonAck.players) {
            var pos = player.trans.position;
            go = GameObject.Instantiate(playerPrefeb,
                                        new Vector3 (pos.x, pos.y, 0),
                                        Quaternion.identity) as GameObject;

            go.transform.SetParent(playerHolder.transform);
            go.GetComponent<Player>().SendMessage("SetPlayerId", player.player_id);

            if(playerMap==null){
                Debug.Log("player map is null");
            }

            playerMap.Add(player.player_id, go);

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

    public void JoinNtf(byte[] ackBin) {
        var ms2 = new MemoryStream(ackBin, 0, ackBin.Length);
        var RoomJoinNtf = ProtoBuf.Serializer.Deserialize<room_join_ntf>(ms2);

        var player = RoomJoinNtf.player;

        var pos = player.trans.position;
        GameObject go = GameObject.Instantiate(playerPrefeb,
                                               new Vector3 (pos.x, pos.y, 0),
                                               Quaternion.identity) as GameObject;
        go.transform.SetParent(playerHolder.transform);
        go.GetComponent<Player>().SendMessage("SetPlayerId", player.player_id);

        playerMap.Add(player.player_id, go);

        Debug.Log("JoinNtf:"+ player.player_id);
    }

    public void LeaveNtf(byte[] ackBin) {
        var ms2 = new MemoryStream(ackBin, 0, ackBin.Length);
        var RoomLeaveNtf = ProtoBuf.Serializer.Deserialize<room_leave_ntf>(ms2);
        var player_id = RoomLeaveNtf.player_id;
        GameObject go;

        if(playerMap.TryGetValue(player_id, out go)) {
            Destroy(go);
        }

        Debug.Log("LeaveNtf:" + player_id);
    }

    public void MoveNtf(byte[] ackBin) {
        Debug.Log("MoveNtf");
        var ms2 = new MemoryStream(ackBin, 0, ackBin.Length);
        var roomMoveNtf = ProtoBuf.Serializer.Deserialize<room_move_ntf>(ms2);
        GameObject go;

        if(!playerMap.TryGetValue(roomMoveNtf.player_id, out go)) {
            return;
        }

        var go_trans = go.GetComponent<Transform>();
        var go_player = go.GetComponent<Player>();
        var proto_pos = roomMoveNtf.trans.position;
        var proto_rotation = roomMoveNtf.trans.position;
        var proto_move = roomMoveNtf.trans.movement;

        go_trans.position = new Vector3(proto_pos.x, proto_pos.y, proto_pos.z);

        var go_move = new Vector3(proto_move.x, proto_move.y, proto_move.z);
        go_player.SendMessage("SetMove", go_move);
        go_player.SendMessage("SetSpeed");

    }

    void Start () {
        _transform = GetComponent<Transform>();

        boxHolder = new GameObject("boxHolder");
        playerHolder = new GameObject("playerHolder");


        playerPrefeb = Resources.Load("player",typeof(GameObject))
            as GameObject;
        box1Prefeb = Resources.Load("box1",typeof(GameObject))
            as GameObject;
        box2Prefeb = Resources.Load("box2",typeof(GameObject))
            as GameObject;
        box3Prefeb = Resources.Load("box3",typeof(GameObject))
            as GameObject;


        Debug.Log("what the fuck");
        RegisterEvent();
    }

    void Update () {
    }

}
