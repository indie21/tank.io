using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    private Camera camera;
    public Transform _player;
    public GameObject _playerObj;

    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {

        if(_player != null){
            transform.position = new Vector3(_player.position.x,
                                             _player.position.y,
                                             -10);
        }


        if (Input.GetKeyUp("c")){
            ServerMessage.Instance.Connect("192.168.199.171", 8881);
        }

        if (Input.GetKeyUp("f")) {
            Event.FireIn("agent_login_req", new object[]{"good"});
        }

        if (Input.GetKeyUp("j")) {
            Event.FireIn("room_join_req", new object[]{});
        }


        if(_playerObj == null) {
            return ;
        }

        var playerScript = _playerObj.GetComponent<Player>();

        if (Input.GetKey ("w")) {
            playerScript.SendMessage("SetMove", Vector3.up);
        } else if (Input.GetKey ("s")) {
            playerScript.SendMessage("SetMove", Vector3.down);
        } else if (Input.GetKey ("a")) {
            playerScript.SendMessage("SetMove", Vector3.left);
        } else if (Input.GetKey ("d")) {
            playerScript.SendMessage("SetMove", Vector3.right);
        } else {
            playerScript.SendMessage("ResetMove");
        }

    }
}
