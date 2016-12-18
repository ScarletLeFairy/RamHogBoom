using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour {

    Ball ball;
    private GameObject item;
    int controllerNumber;

	// Use this for initialization
	void Start () {
        controllerNumber = 1;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (GetRightBumper())
        {
            if (ball != null)
            {   // throw ball
                ThrowBall();
            } else
            {
                // dash
                Debug.Log("Dash");
            }
            //if (item != null) // throw item
            //{
            //    item = null;
            //} 
        }
    }

    private void ThrowBall()
    {
        ball.GetComponent<BallBehaviour>().Owner = null;
        ball = null;
    }


    void OnTriggerEnter(Collider other)
    {
        if (ball != null)
        {
            // already picked up the ball 
            Debug.Log("");
        }
        else
        {
            GameObject oth = other.transform.root.gameObject;
            if (oth == SceneDirector.Ball)
            {
                ball = SceneDirector.Ball; // wenn trigger von Ball dann Ball aufheben   
                ball.GetComponent<BallBehaviour>().Owner = gameObject;      
            }
            else
            {
                // other object, maybe another player


                // sonst item aufheben überprüfen (nicht mehr)
                //if (item != null)
                //{
                //    // already picked up an item
                //    Debug.Log("");
                //}
                //else
                //{
                //    // pick up item
                //    Debug.Log("");
                //}
            }
        }
    }

    bool GetRightBumper()
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
}
