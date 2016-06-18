using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    private Transform m_transform;
    private Vector3 m_Move;
    public float _speed = 0f;

    // Use this for initialization
    void Start () {
        m_transform = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update () {
        m_transform.position += m_Move * _speed;
    }

    void SetMove(Vector3 vec3) {
        m_Move = vec3;
    }

    void SetSpeed(float speed) {
        _speed = speed;
    }

}
