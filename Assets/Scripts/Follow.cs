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
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
