using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowMenuHolder : MonoBehaviour {

	public GameObject Background;
	public GameObject Pause;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.JoystickButton7))
		{
			Background.SetActive (!Pause.activeSelf);
			Pause.SetActive (!Pause.activeSelf);
			Debug.Log ("start");
		}
	}

}
