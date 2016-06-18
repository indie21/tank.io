using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    private Camera camera;
    public Transform player;

    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        if(player != null){
            transform.position = new Vector3(player.position.x,
                                             player.position.y,
                                             -10);
        }

        if (Input.GetKeyUp("c")){
            ServerMessage.Instance.Connect("127.0.0.1", 8881);
        }

        if (Input.GetKeyUp("f")) {
            Event.FireIn("agent_login_req", new object[]{"good"});
        }

        if (Input.GetKeyUp("j")) {
            Event.FireIn("room_join_req", new object[]{});
        }
    }
}
