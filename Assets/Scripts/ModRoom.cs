using proto.packet;
using proto.payload;
using UnityEngine;
using System.IO;
using System.Net.Sockets;

public class ModRoom  : MonoBehaviour {
    public Transform m_transform;

    private Transform boxHolder;

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
        GameObject prefeb;
        GameObject go;

        var box1 = Resources.Load("box1",typeof(GameObject)) as GameObject;
        var box2 = Resources.Load("box2",typeof(GameObject)) as GameObject;
        var box3 = Resources.Load("box3",typeof(GameObject)) as GameObject;

        var BoxArray = new GameObject[]{box1, box2, box3};

        foreach(var box in RoomJonAck.boxs) {
            Debug.Log("box "+box.type+" array size:");

            if(BoxArray == null){
                Debug.Log("BoxArray null");
            }

            prefeb = BoxArray[box.type-1];

            if(prefeb == null){
                Debug.Log("prefe null");
            } else {
                Debug.Log("prefeb:"+prefeb+ "box:" + box.type);
				var pos = box.trans.position;
                go = GameObject.Instantiate(prefeb,
                                            new Vector3 (pos.x, pos.y, 0),
                                            Quaternion.identity) as GameObject;
                go.transform.SetParent(boxHolder);
            }

        }
    }

    void Awake () {
        boxHolder = new GameObject("box").transform;
    }

    void Start () {
        m_transform = GetComponent<Transform>();
    }

    void Update () {
    }

}
