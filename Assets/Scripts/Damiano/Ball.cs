using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Player owner = null;

	float mass = 1;
	float groundlevel = 0;

	// Use this for initialization
	void Awake () {
		groundlevel = GetComponent<Collider>().bounds.extents.y;
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
	
	}


	void Launch(){

	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, groundlevel*1.1f);
	}


}
