using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float speed = 6;
	public float turnSmoothing = 6f;

	Rigidbody rigid;

	public enum Slot{
		Player_1,
		Player_2,
		Player_3,
		Player_4,
		Player_5,
		Player_6,
		Player_7,
		Player_8,
		Player_9,
		Player_10
	}

	public Slot slot;

	public enum Faction{
		HOG,
		RAM
	}
	public Faction faction;

	// Use this for initialization
	void Awake() {
		rigid = GetComponent<Rigidbody> ();
	}

	Vector2 joyDir = Vector2.zero;

	void FixedUpdate(){
		Vector3 moveDir = Vector3.forward * joyDir.x + Vector3.right * joyDir.y;

		if (moveDir.magnitude != 0) {
			Quaternion targetRotation = Quaternion.LookRotation (moveDir, Vector3.up);
			Debug.DrawLine (transform.position + Vector3.up, transform.position + Vector3.up + targetRotation * Vector3.forward, Color.green);

			float factor = 1 - Quaternion.Angle( transform.rotation, targetRotation )/360f;

			Quaternion deltaRotation = Quaternion.Slerp(transform.rotation, targetRotation, Mathf.Pow(turnSmoothing, factor) * Time.deltaTime);
			Debug.DrawLine (transform.position + Vector3.up, transform.position + Vector3.up + deltaRotation * Vector3.forward, Color.yellow);



			rigid.MoveRotation(deltaRotation);
		}


		//Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);

		//rigid.MoveRotation(rotation);
		rigid.MovePosition(transform.position + moveDir * speed * Time.deltaTime);
	}

	// Update is called once per frame
	void Update () {
		joyDir = new Vector2 (Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
	}
}
