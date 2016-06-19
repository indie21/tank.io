using UnityEngine;
using proto.packet;
using proto.payload;
//using System.Collections;


public class Player : MonoBehaviour {

    private int m_level = 1;
    private static Vector3 z_Move = new Vector3(0,0,0);

    public Vector3 _Move;

    private SpriteRenderer m_spriteRender;
    private Transform m_transform;
    public float _speed = 0.05f;
    public int _player_id;

    void Test() {
    }

    void Awake() {
        ResetMove();
    }

       // Use this for initialization
    void Start ()  {
        m_spriteRender = GetComponent<SpriteRenderer> ();
        m_transform = GetComponent<Transform> ();
        // Debug.Log ("sprite render");
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown("space")){
            LevelUp ();
        }

        m_transform.position += _Move*_speed;
    }

    void SetMove(Vector3 vec3) {
        if(_Move != vec3){
            _Move = vec3;
            FireMoveReq();
        }
    }

    void ResetMove() {
        if(_Move != z_Move) {
            _Move = z_Move;
            FireMoveReq();
        }
    }


    void LevelUp() {
        m_level += 1;
        var name_1 = string.Format ("Tank_{0:D2}", m_level);
        Debug.Log ("name:" + name_1);
        var levelSprite = Resources.Load (name_1, typeof(Sprite)) as Sprite;
        m_spriteRender.sprite = levelSprite;
    }

    void FireMoveReq() {

        // Debug.Log("game manager id "+
        // GameManager._userId + "move "+ _player_id);

        if(_player_id != GameManager._userId){
            return;
        }

        proto.payload.transform transProto = new proto.payload.transform();
        transProto.position = new proto.payload.vector3();
        transProto.position.x = transform.position.x;
        transProto.position.y = transform.position.y;
        transProto.position.z = transform.position.z;

        transProto.rotation = new proto.payload.vector3();
        transProto.rotation.x = transform.rotation.x;
        transProto.rotation.y = transform.rotation.y;
        transProto.rotation.z = transform.rotation.z;

        transProto.movement = new proto.payload.vector3();
        transProto.movement.x = _Move.x;
        transProto.movement.y = _Move.y;
        transProto.movement.z = _Move.z;

        transProto.speed = _speed;

        Event.FireIn("room_move_req", new object[]{transProto});
    }

    void SetPlayerId(int playerid) {
        _player_id = playerid;
    }
}
