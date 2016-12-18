using UnityEngine;
using System.Collections;

public class PlayCam : MonoBehaviour {

	public static PlayCam master = null;

	float gametime = 0;
	public int points = 0;

	Camera cam;

	CamAnchor[] anchor = new CamAnchor[]{
		new CamAnchor(new Vector3(71f, 20f, 5f)),
		new CamAnchor(new Vector3(31f, 20f, 5f)),
		new CamAnchor(new Vector3(-12.5f, 20f, 5f)),
		new CamAnchor(new Vector3(-56f, 20f, 5f)),
		new CamAnchor(new Vector3(-97f, 20f, 5f))
	};

	GameObject[,,] spawns = new GameObject[5,2,4];

	// Use this for initialization
	void Awake (){
		master = this;

		cam = gameObject.GetComponent<Camera>();
		cam.depthTextureMode = DepthTextureMode.Depth;

		points = 0;
		gametime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		NextRound ();
	}

	public static void ScorePoint(int i){
		master.points += i;
	}

	void NextRound (){
		cam.transform.position = anchor[points + 2].position;
		/*foreach (Player player in Player.players) {
			
		}*/
	}
}

class CamAnchor{
	public Vector3 position;

	public CamAnchor(Vector3 position){
		this.position = position;
	}
}
