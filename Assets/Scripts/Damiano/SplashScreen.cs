using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	float time;

	// Use this for initialization
	void Awake () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (time + 3 <= Time.time) {
			SceneManager.LoadScene("Menu");
		}
	}
}
