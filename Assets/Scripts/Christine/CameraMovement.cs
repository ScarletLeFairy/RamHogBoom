using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private float shakeAmount;
    private float shakeTimer;

    private GameObject currentTarget;
    public GameObject targetMiddle; // assign in editor
    public GameObject targetMiddleLeft; // assign in editor
    public GameObject targetMiddleRight; // assign in editor
    public GameObject targetLeft; // assign in editor
    public GameObject targetRight; // assign in editor

    void Start ()
    {
        // set middle plane as start target
        currentTarget = targetMiddle;            
        
    }
    

    // Update is called once per frame
    void Update () {

        if (GetButtonA())
        {
            ShakeCamera(0.1f, 1);
        }

        if (shakeTimer >= 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
            
            // TODO include Controller vibrations :3
        }

    }

    private void ShakeCamera(float shakePower, float shakeDuration)
    {
        shakeAmount = shakePower;
        shakeTimer = shakeDuration;
    }


    private bool GetButtonA()
    {
        return Input.GetKeyDown(KeyCode.JoystickButton0);
    }



    public void SwitchToMiddlePlane()
    {

    }

    public void SwitchToMiddleRightPlane()
    {

    }

    public void SwitchToRightPlane()
    {

    }

    public void SwitchToMiddleLeftPlane()
    {

    }

    public void SwitchToLeftPlane()
    {

    }


}
