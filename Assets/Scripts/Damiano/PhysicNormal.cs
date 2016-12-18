using UnityEngine;
using System.Collections;

public class PhysicNormal : MonoBehaviour {

	Rigidbody rigid;

	Vector2 joyDirL = Vector2.zero;
	Vector2 joyDirR = Vector2.zero;
	float stun = 0;

	Dashing dash = null;

	public Slot slot;
	public enum Slot{
		Player_1,
		Player_2,
		Player_3,
		Player_4,
		Player_5,
		Player_6,
		Player_7,
		Player_8
	}

	void Awake() {
		//rigid = GetComponent<Rigidbody> (); 
		rigid = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		//Vector3 dir = Vector3.forward;

		Vector3 moveDir = Vector3.forward * joyDirL.x + Vector3.right * joyDirL.y;

		rigid.AddForce (moveDir*6, ForceMode.Acceleration);
	}

	void Update () {
		joyDirL = new Vector2 (GetLeftStickY(), GetLeftStickX());
		joyDirR = new Vector2 (GetRightStickY(), GetRightStickX());

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
