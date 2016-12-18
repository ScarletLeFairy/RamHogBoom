using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

	public GameObject PlayerPref;
	public Vector3 spawn = Vector3.zero;
	public float range = 10;


	void Awake(){
		Player.players = new List<Player>();
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Joystick1Button5) || Input.GetKeyDown (KeyCode.Joystick1Button0)){

			bool valid = true;
			foreach (Player player in Player.players) {
				valid = player.slot == Player.Slot.Player_1 ? false : valid;
			}

			if (valid) {
				GameObject player = Instantiate(PlayerPref);
				Player script = player.GetComponent<Player> ();
				Player.players.Add (script);
				script.slot = Player.Slot.Player_1;
			}

			/*while (valid) {
				Vector3 targetPosition = new Vector3(spawn.x + Random.Range(-range,range), spawn.y, spawn.z + Random.Range(-range,range));

				Debug.Log (targetPosition);
				valid = false;

				Collider[] hitColliders = Physics.OverlapSphere(targetPosition + Vector3.up * 3, 1);

				foreach (Collider col in hitColliders) {
					Debug.Log (col.gameObject.name);
				}
				Debug.Log ("#" + hitColliders.Length);

				/*if (){
					Debug.Log ("NO COLLISION");
					GameObject player = (GameObject)Instantiate(PlayerPref, targetPosition, Quaternion.Euler(0,0,0));

					Player script = player.GetComponent<Player> ();
					Player.players.Add (script);
					script.slot = Player.Slot.Player_1;

					valid = false;
					//obstacles[x] = Instantiate(obstacleTypes[(Random.Range(0,2))], targetPosition, transform.rotation);
				}
			}*/
		}
		if (Input.GetKeyDown (KeyCode.Joystick2Button5) || Input.GetKeyDown (KeyCode.Joystick2Button0)){

			bool valid = true;
			foreach (Player player in Player.players) {
				valid = player.slot == Player.Slot.Player_2 ? false : valid;
			}
			if (valid) {
				GameObject player = Instantiate(PlayerPref);
				Player script = player.GetComponent<Player> ();
				Player.players.Add (script);
				script.slot = Player.Slot.Player_2;
			}
		}
		if (Input.GetKeyDown (KeyCode.Joystick3Button5) || Input.GetKeyDown (KeyCode.Joystick3Button0)){

			bool valid = true;
			foreach (Player player in Player.players) {
				valid = player.slot == Player.Slot.Player_3 ? false : valid;
			}
			if (valid) {
				GameObject player = Instantiate(PlayerPref);
				Player script = player.GetComponent<Player> ();
				Player.players.Add (script);
				script.slot = Player.Slot.Player_3;
			}
		}
		if (Input.GetKeyDown (KeyCode.Joystick4Button5) || Input.GetKeyDown (KeyCode.Joystick4Button0)){

			bool valid = true;
			foreach (Player player in Player.players) {
				valid = player.slot == Player.Slot.Player_4 ? false : valid;
			}
			if (valid) {
				GameObject player = Instantiate(PlayerPref);
				Player script = player.GetComponent<Player> ();
				Player.players.Add (script);
				script.slot = Player.Slot.Player_4;
			}
		}


		if (Input.GetKeyDown (KeyCode.Joystick5Button5) || Input.GetKeyDown (KeyCode.Joystick5Button0)){

			bool valid = true;
			foreach (Player player in Player.players) {
				valid = player.slot == Player.Slot.Player_5 ? false : valid;
			}
			if (valid) {
				GameObject player = Instantiate(PlayerPref);
				Player script = player.GetComponent<Player> ();
				Player.players.Add (script);
				script.slot = Player.Slot.Player_5;
			}
		}
		if (Input.GetKeyDown (KeyCode.Joystick6Button5) || Input.GetKeyDown (KeyCode.Joystick6Button0)){

			bool valid = true;
			foreach (Player player in Player.players) {
				valid = player.slot == Player.Slot.Player_6 ? false : valid;
			}
			if (valid) {
				GameObject player = Instantiate(PlayerPref);
				Player script = player.GetComponent<Player> ();
				Player.players.Add (script);
				script.slot = Player.Slot.Player_6;
			}
		}
		if (Input.GetKeyDown (KeyCode.Joystick3Button7) || Input.GetKeyDown (KeyCode.Joystick7Button0)){

			bool valid = true;
			foreach (Player player in Player.players) {
				valid = player.slot == Player.Slot.Player_7 ? false : valid;
			}
			if (valid) {
				GameObject player = Instantiate(PlayerPref);
				Player script = player.GetComponent<Player> ();
				Player.players.Add (script);
				script.slot = Player.Slot.Player_7;
			}
		}
		if (Input.GetKeyDown (KeyCode.Joystick8Button5) || Input.GetKeyDown (KeyCode.Joystick8Button0)){

			bool valid = true;
			foreach (Player player in Player.players) {
				valid = player.slot == Player.Slot.Player_8 ? false : valid;
			}
			if (valid) {
				
				/*while (valid) {
					Vector3 targetPosition = Vector3(spawn.x + Random.Range(-range,range), spawn.y, spawn.z + Random.Range(-range,range));

					if ((Physics.OverlapSphere(targetPosition, 5, 0, 0, 0)) == null){
						GameObject player = Instantiate(PlayerPref, targetPosition);

						Player script = player.GetComponent<Player> ();
						Player.players.Add (script);
						script.slot = Player.Slot.Player_8;

						valid = false;
						//obstacles[x] = Instantiate(obstacleTypes[(Random.Range(0,2))], targetPosition, transform.rotation);
					}
				}*/


			}
		}

		int hog_count = 0;
		int ram_count = 0;

		foreach (Player player in Player.players) {
			if (player.faction == Player.Faction.RAM) {
				ram_count += 1;
			}

			if (player.faction == Player.Faction.HOG) {
				hog_count += 1;
			}

			if(player.transform.position.x < 0 && player.faction != Player.Faction.RAM){
				player.faction = Player.Faction.RAM;

			}
			if(player.transform.position.x > 0 && player.faction != Player.Faction.HOG){
				player.faction = Player.Faction.HOG;

			}
		}

		//Debug.Log (hog_count + " " + ram_count + " " + lobbytime);

		if (hog_count == ram_count && (hog_count + ram_count) >= 2 && lobbytime == -1) {
			lobbytime = Time.time;
		}

		if (hog_count != ram_count) {
			lobbytime = -1;
		}

		if (lobbytime + 10 < Time.time && lobbytime != -1) {
			SceneManager.LoadScene("Play");
		}


	}

	float lobbytime = -1;
}

