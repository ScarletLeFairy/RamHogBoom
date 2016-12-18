using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private float shakeAmount;
    private float shakeTimer;

    // Update is called once per frame
    void Update () {

        //if (GetButtonA())
        //{
        //    ShakeCamera(0.1f, 1);
        //}

        if (shakeTimer >= 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;           
        }

    }

    public void ShakeCamera(float shakePower, float shakeDuration)
    {
        shakeAmount = shakePower;
        shakeTimer = shakeDuration;
    }

    //private bool GetButtonA()
    //{
    //    return Input.GetKeyDown(KeyCode.JoystickButton0);
    //}

}
