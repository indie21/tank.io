using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int _userId;
    public static ModAgent _modAgent = new ModAgent();
    public static ModRoom _modRoom = new ModRoom();

    void Start () {
        MessageMap.Install();
        _modAgent.RegisterEvent();
        _modRoom.RegisterEvent();
    }

    // Update is called once per frame
    void Update () {
        Event.ProcessOut();
    }

}

