using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {



	public bool isAlive = true;
    float speed = 6;
	public float turnSmoothing = 6f;

	//Rigidbody rigid;
	Collider rigid;

	public Slot slot;
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
		
	public Faction faction;
	public enum Faction{
		HOG,
		RAM
	}

	public static List<PlayerControllerAdv> players = new List<PlayerControllerAdv>();



	// Use this for initialization
	void Awake() {
		//rigid = GetComponent<Rigidbody> (); 
		rigid = transform.Find("Mesh").GetComponent<Collider>();
    }

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("Collision:" + col.gameObject.name);
	}

	Vector2 joyDir = Vector2.zero;

	void FixedUpdate(){
		Vector3 moveDir = Vector3.forward * joyDir.x + Vector3.right * joyDir.y;

		//ROTATION
		if (moveDir.magnitude != 0) {
			Quaternion targetRotation = Quaternion.LookRotation (moveDir, Vector3.up);
			//Debug.DrawLine (transform.position + Vector3.up, transform.position + Vector3.up + targetRotation * Vector3.forward, Color.green);

			float factor = 1 - Quaternion.Angle( transform.rotation, targetRotation )/360f;
			Quaternion deltaRotation = Quaternion.Slerp(transform.rotation, targetRotation, Mathf.Pow(turnSmoothing, factor) * Time.deltaTime);
			//Debug.DrawLine (transform.position + Vector3.up, transform.position + Vector3.up + deltaRotation * Vector3.forward, Color.yellow);

			transform.rotation = deltaRotation;
			//rigid.MoveRotation(deltaRotation);
		}
			

		Vector3 deltaPosition = moveDir * speed * Time.deltaTime;

		float adjustment = 0;
		if (rigid is CapsuleCollider) {
			CapsuleCollider c = (CapsuleCollider)rigid;
			adjustment = c.radius;
		}

		//Debug.Log (deltaPosition.magnitude);
		RaycastHit hit;
		if (!Physics.SphereCast(transform.position,adjustment, deltaPosition.normalized, out hit, deltaPosition.magnitude, Physics.DefaultRaycastLayers , QueryTriggerInteraction.Ignore)){
			transform.position = transform.position + deltaPosition;
			//if (Physics.Raycast (transform.position, deltaPosition.normalized, out hit, deltaPosition.magnitude + adjustment)) {
			//
		} 
		/*else {
			Debug.Log ("Found an object - distance: " + hit.distance + " " + hit.collider.gameObject.name);	
		}*/

	}

	// Update is called once per frame
	void Update () {
        //Debug.Log("X: " + GetLeftStickX() + " | Y: " + GetLeftStickY());
		joyDir = new Vector2 (GetLeftStickY(), GetLeftStickX());
	}
		

	int GetControllerID(){

		int id = -1;

		switch(slot){
		case Slot.Player_1:
			id = 1;
			break;

		case Slot.Player_2:
			id = 2;
			break;

		case Slot.Player_3:
			id = 3;
			break;

		case Slot.Player_4:
			id = 4;
			break;

		case Slot.Player_5:
			id = 5;
			break;

		case Slot.Player_6:
			id = 6;
			break;

		case Slot.Player_7:
			id = 7;
			break;

		case Slot.Player_8:
			id = 8;
			break;
		}

		return id;
	}

    bool GetRightBumper(){
        
		switch (GetControllerID()){
            case 1: return Input.GetKeyDown(KeyCode.Joystick1Button5);
            case 2: return Input.GetKeyDown(KeyCode.Joystick2Button5);
            case 3: return Input.GetKeyDown(KeyCode.Joystick3Button5);
            case 4: return Input.GetKeyDown(KeyCode.Joystick4Button5);
            case 5: return Input.GetKeyDown(KeyCode.Joystick5Button5);
            case 6: return Input.GetKeyDown(KeyCode.Joystick6Button5);
            case 7: return Input.GetKeyDown(KeyCode.Joystick7Button5);
            case 8: return Input.GetKeyDown(KeyCode.Joystick8Button5);
            // Unity does not support buttons for more than 8 joysticks
            default: return false;
        }
    }

    float GetLeftStickX()
    {
		int id = GetControllerID ();
        if (id < 1 || id > 8)
        {
            Debug.Log("Invalid controller number");
            return 0;
        }
        return Input.GetAxis("P" + id + "LeftStickX");
    }

    float GetLeftStickY()
    {
		int id = GetControllerID ();
        if (id < 1 || id > 8)
        {
            Debug.Log("Invalid controller number");
            return 0;
        }
        return Input.GetAxis("P" + id + "LeftStickY");
    }

    float GetRightStickX()
    {
		int id = GetControllerID ();
		if (id < 1 || id > 8)
        {
            Debug.Log("Invalid controller number");
            return 0;
        }
        return Input.GetAxis("P" + id + "RightStickX");
    }

    float GetRightStickY()
    {
		int id = GetControllerID ();
        if (id < 1 || id > 8)
        {
            Debug.Log("Invalid controller number");
            return 0;
        }
        return Input.GetAxis("P" + id + "RightStickY");
    }


}
