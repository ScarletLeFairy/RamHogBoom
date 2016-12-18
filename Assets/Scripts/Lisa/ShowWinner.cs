using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShowWinner : MonoBehaviour {

	public GameObject WinnerRams;
	public GameObject WinnerHogs;
	public AudioSource sound;

	//Set this bool to decide the winner
	public static bool ramsWin;

	public void SetWinner(bool rams){
		WinnerRams.SetActive (rams);
		WinnerHogs.SetActive (!rams);
		ramsWin = rams;
	}

	public void SetWinner(){
		WinnerRams.SetActive (ramsWin);
		WinnerHogs.SetActive (!ramsWin);
	}

	// Use this for initialization
	void Start () {
		SetWinner ();
		sound.volume = SFXManager.volume;
		if (!sound.isPlaying) {
			sound.Play ();
		}
	}

	void Update(){
		if (ramsWin != WinnerRams.activeSelf) {
			SetWinner ();
		}
		if (Input.GetKeyDown (KeyCode.Joystick8Button0) || Input.GetKeyDown (KeyCode.Joystick8Button7) || Input.GetKeyDown (KeyCode.Joystick8Button6)) {
			Canvas[] containers = FindObjectsOfType<Canvas> ();
			if (containers != null) {
				foreach(Canvas container in containers){
					if (container.name == "Menu Holder") {
						Destroy (container);
					}
				}
			}
			SceneManager.LoadScene (MySceneManager.MENU_SCENE);
		}
	}

}
