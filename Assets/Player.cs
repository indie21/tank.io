using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	private int m_level = 1;	
	private Vector3 m_Move;
	public float m_Speed = 0.1f;
	private SpriteRenderer m_spriteRender;
	private Transform m_transform;

	// Use this for initialization
	void Start () {
		m_spriteRender = GetComponent<SpriteRenderer> ();
		m_transform = GetComponent<Transform> ();
		Debug.Log ("sprite render");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){ 
			LevelUp ();
		}

		if (Input.GetKey ("w")) { 
			m_Move = Vector3.up * m_Speed;
			Move ();
		} else if (Input.GetKey ("s")) {
			m_Move = Vector3.down * m_Speed;
			Move ();
		} else if (Input.GetKey ("a")) {
			m_Move = Vector3.left * m_Speed;
			Move ();
		}
		else if (Input.GetKey ("d")) {
			m_Move = Vector3.right * m_Speed;
			Move ();
		}

	}

	void LevelUp() {
		m_level += 1;
		string name = string.Format ("Tank_{0:D2}", m_level);
		Debug.Log ("name:" + name);
		Sprite levelSprite = Resources.Load (name, typeof(Sprite)) as Sprite;
		m_spriteRender.sprite = levelSprite;
	}

	void Move() {
		m_transform.position += m_Move;
	}
}
