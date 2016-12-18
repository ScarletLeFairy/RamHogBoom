using UnityEngine;
using System.Collections;

public class PlayCam : MonoBehaviour {

	public static PlayCam master = null;


	float gametime = 0;

	public int start = 0;
	public int points = 0;

	Camera cam;

	public GameObject[] CameraSpawns;

	public SpawnZones[] DragonSpawns;
	public SpawnZones[] RedSpawns;
	public SpawnZones[] BlueSpawns;


	public GameObject activeSpawn;
	public GameObject PrefBall;
	GameObject ball = null;

	bool refresh = true;

	// Use this for initialization
	void Awake (){
		master = this;

		cam = gameObject.GetComponent<Camera>();
		cam.depthTextureMode = DepthTextureMode.Depth;

		cam.transform.position = new Vector3 (0, 100, 15);
		cam.transform.rotation = Quaternion.Euler(80, 180, 0);

		points = start;
		gametime = Time.time;

		foreach (Player obj in Player.players) {

			Player player = obj;
			//player.GetComponent<Renderer> ().enabled = false;
		}

		refresh = true;
	}
	
	// Update is called once per frame
	void Update () {
		MoveCamera ();

	}

	public static void ScorePoint(int i){
		master.points += i;
	}

	void MoveCamera (){

		Vector3 targetLocation = Vector3.zero;
		Quaternion targetRotation = Quaternion.identity;
		if ((points) > -3 && (points) < 3) {
			targetLocation = new Vector3 (CameraSpawns [points + 2].transform.position.x, 20f, 5f);
			targetRotation = Quaternion.Euler(80, 180, 0);

		} else {
			targetLocation = new Vector3 (0, 7.6f, 2.1f);
			targetRotation = Quaternion.Euler(50, 180, 0);
		}

		cam.transform.position = Vector3.Slerp (cam.transform.position, targetLocation, 2f * Time.deltaTime);
		cam.transform.rotation = Quaternion.Slerp (cam.transform.rotation, targetRotation, 2f * Time.deltaTime);

		if(Vector3.Distance(cam.transform.position, targetLocation) < 1 && refresh){
			NextRound();
			refresh = false;
		}
		/*foreach (Player player in Player.players) {
			
		}*/
	}

	void NextRound (){

		refresh = false;

		int hog_count = 0;
		int ram_count = 0;

		foreach (Player obj in Player.players) {

			Player player = obj;
			player.IsDead = false;

			//player.GetComponent<Renderer> ().enabled = true;

			if (player.faction == Player.Faction.HOG) {
				Vector3 spawn = RedSpawns [points + 2].spawn [hog_count].transform.position;
				//Debug.Log (player.name + " HOG " + spawn);
				player.transform.position = spawn;
				player.transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);

				hog_count += 1;
			}

			if (player.faction == Player.Faction.RAM) {
				Vector3 spawn = BlueSpawns [points + 2].spawn [ram_count].transform.position;
				//Debug.Log (player.name + " RAM " + spawn);
				player.transform.position = spawn;
				player.transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);

				ram_count += 1;
			}
		}

		if (ball != null) {
			Destroy(ball);
		}

		ball = (GameObject)Instantiate(PrefBall, activeSpawn.transform.position, Quaternion.LookRotation(Vector3.forward, Vector3.up));

		//ball.transform.position = activeSpawn.transform.position;
		//ball.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

	}
}

class CamAnchor{
	public Vector3 position;

	public CamAnchor(Vector3 position){
		this.position = position;
	}
}
