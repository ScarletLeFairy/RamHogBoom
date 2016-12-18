using UnityEngine;
using System.Collections;

public class PhysicSim : MonoBehaviour {

	Rigidbody rigid;

	void Awake() {
		rigid = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dir = Vector3.forward;
		rigid.velocity += Vector3.forward * 20 * Mathf.Pow(Time.fixedDeltaTime, 1);
		//rigid.AddForce (dir, ForceMode.Acceleration);
	}
}