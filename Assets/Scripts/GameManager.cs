using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int _userId;
    private static ModAgent _modAgent = new ModAgent();
    private static ModRoom _modRoom = new ModRoom();

    void Start () {
        MessageMap.Install();
        _modAgent.RegisterEvent();
    }

    // Update is called once per frame
    void Update () {
        Event.ProcessOut();
    }

}

