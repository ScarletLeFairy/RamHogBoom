using UnityEngine;
using System.Collections;

public class PlayCam : MonoBehaviour {

	// Use this for initialization
	void Start (){
		Camera cam = gameObject.GetComponent<Camera>();
		cam.depthTextureMode = DepthTextureMode.Depth;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
