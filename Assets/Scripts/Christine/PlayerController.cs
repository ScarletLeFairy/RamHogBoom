using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private static int[] controls;
    public static int[] Controls
    {
        get { return controls; }
    }

    private int controllerNumber;
    public int ControllerNumber
    {
        get { return controllerNumber; }
        set { controllerNumber = value; }
    }

    private CharacterController controller;

    public float speed = 5;

    // Use this for initialization
    void Start () {
        controllerNumber = 1;

        if (GetComponent<CharacterController>() == null)
        {
            gameObject.AddComponent<CharacterController>();
        }
        controller = GetComponent<CharacterController>();
        
}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        float leftX = Input.GetAxis("P1LeftStickX");
        float leftY = Input.GetAxis("P1LeftStickX");
        //float leftX = GetLeftStickX();
        //float leftY = GetLeftStickY();
        //float rightX = GetLeftStickX();
        //float rightY = GetLeftStickY();
        //Debug.Log(GetRightBumper());

        //Debug.Log(gameObject.name + " leftX: " + leftX + "|leftY: " + leftY);
        //Debug.Log(gameObject.name + " rightX: " + rightX + "|rightX: " + rightY);

        //Vector3 movementDirection = new Vector3(leftX, 0, leftY).normalized;
        Vector3 lookDirection = new Vector3(leftX, 0, leftY).normalized;
        //Debug.Log(direction);

        //if (lookDirection != Vector3.zero)
        //{
        //    Quaternion rotation = Quaternion.LookRotation(lookDirection);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 8);

        //    lookDirection = transform.forward;
        //}
        Vector3 movement = Vector3.zero;
        movement = lookDirection * speed;


        //if (controller.isGrounded && getButtonA() && throwable == null)
        //{
        //    amplitude = 10;
        //}

        //amplitude = -gravity > amplitude - gravity * Time.deltaTime ? -gravity : amplitude - gravity * Time.deltaTime;
        //movement.y = amplitude;

        controller.Move(movement * Time.deltaTime);
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
