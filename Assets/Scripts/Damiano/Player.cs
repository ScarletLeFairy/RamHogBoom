using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int controllerNumber;
    public int ControllerNumber
    {
        get { return controllerNumber; }
        set { controllerNumber = value; }
    }

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

        controllerNumber = -1;
        switch(slot)
        {
            case Slot.Player_1:
                controllerNumber = 1;
                break;

            case Slot.Player_2:
                controllerNumber = 2;
                break;

            case Slot.Player_3:
                controllerNumber = 3;
                break;

            case Slot.Player_4:
                controllerNumber = 4;
                break;

            case Slot.Player_5:
                controllerNumber = 5;
                break;

            case Slot.Player_6:
                controllerNumber = 6;
                break;

            case Slot.Player_7:
                controllerNumber = 7;
                break;

            case Slot.Player_8:
                controllerNumber = 8;
                break;
        }
       
 
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
        Debug.Log("X: " + GetLeftStickX() + " | Y: " + GetLeftStickY());
		joyDir = new Vector2 (GetLeftStickY(), GetLeftStickX());
	}

    private bool GetRightBumper()
    {
        switch (controllerNumber)
        {
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

    private float GetLeftStickX()
    {
        if (controllerNumber < 1 || controllerNumber > 8)
        {
            Debug.Log("Invalid controller number");
            return 0;
        }
        return Input.GetAxis("P" + controllerNumber + "LeftStickX");
    }

    private float GetLeftStickY()
    {
        if (controllerNumber < 1 || controllerNumber > 8)
        {
            Debug.Log("Invalid controller number");
            return 0;
        }
        return Input.GetAxis("P" + controllerNumber + "LeftStickY");
    }

    private float GetRightStickX()
    {
        if (controllerNumber < 1 || controllerNumber > 8)
        {
            Debug.Log("Invalid controller number");
            return 0;
        }
        return Input.GetAxis("P" + controllerNumber + "RightStickX");
    }

    private float GetRightStickY()
    {
        if (controllerNumber < 1 || controllerNumber > 8)
        {
            Debug.Log("Invalid controller number");
            return 0;
        }
        return Input.GetAxis("P" + controllerNumber + "RightStickY");
    }

}
