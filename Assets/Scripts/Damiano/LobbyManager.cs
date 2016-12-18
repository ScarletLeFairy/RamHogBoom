using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LobbyManager : MonoBehaviour {

	public GameObject PlayerPref;

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
				GameObject player = Instantiate(PlayerPref);
				Player script = player.GetComponent<Player> ();
				Player.players.Add (script);
				script.slot = Player.Slot.Player_8;
			}
		}
	}


}
