using UnityEngine;
using System.Collections;

public class PlayCam : MonoBehaviour {

	public static PlayCam master = null;

	float gametime = 0;

	public int start = 0;
	int points = 0;

	Camera cam;

	CamAnchor[] anchor = new CamAnchor[]{
		new CamAnchor(new Vector3(83.5f, 20f, 5f)),
		new CamAnchor(new Vector3(44.5f, 20f, 5f)),
		new CamAnchor(new Vector3(0f, 20f, 5f)),
		new CamAnchor(new Vector3(-43.5f, 20f, 5f)),
		new CamAnchor(new Vector3(-84.5f, 20f, 5f))
	};

	public GameObject[] CameraSpawns;

	public SpawnZones[] DragonSpawns;
	public SpawnZones[] RedSpawns;
	public SpawnZones[] BlueSpawns;

	// Use this for initialization
	void Awake (){
		master = this;

		cam = gameObject.GetComponent<Camera>();
		cam.depthTextureMode = DepthTextureMode.Depth;

		points = start;
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
		cam.transform.position = new Vector3(CameraSpawns[points + 2].transform.position.x, 20f, 5f) ;
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
