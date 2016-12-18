using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Player2 owner = null;

	Renderer render;
	Collider rigid;

	float mass = 1;
	float groundlevel = 0;

	// Use this for initialization
	void Awake () {
		render = GetComponent<Renderer> ();
		rigid = GetComponent<Collider> ();
		groundlevel = rigid.bounds.extents.y;
	}

	void FixedUpdate(){
		if (!IsGrounded()) {
			float gravity = 9.81f * Time.deltaTime / mass;
			transform.position = new Vector3 (transform.position.x, transform.position.y - gravity, transform.position.z);
		}
	}

	float GetGravity(){
		//time += timestep;
		//position += timestep * (velocity + timestep * acceleration / 2);
		//velocity += timestep * acceleration;
		return 0;
	}

	// Update is called once per frame
	void Update () {
		if (owner != null) {
			render.enabled = false;
			rigid.enabled = false;
		}

	}


	void Launch(){

	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, groundlevel*1.1f);
	}

	/*void OnCollisionEnter(Collision other) {
		foreach (ContactPoint contact in other.contacts) {
			Debug.DrawRay (contact.point, contact.normal, Color.white);
		}
		Debug.Log(other.gameObject.name);

	}*/


	void OnTriggerStay(Collider other) {
		//Debug.Log("HIT");
	}

	void OnColliderStay(Collider other) {
		//Debug.Log("HIT");
	}

	/*void OnCollisionEnter(Collider other){

		Debug.Log(other.gameObject.name);

		Player player = other.GetComponent<Player> ();

		if (player != null) {
			owner = player;
		}
			  
	}*/

}
