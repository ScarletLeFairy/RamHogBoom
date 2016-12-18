using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public Player.Faction faction = Player.Faction.HOG;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisonEnter(Collision c){

		GameObject obj = c.transform.root.gameObject;
		Player player = obj.GetComponent<Player> ();

		if (player != null && player.faction != faction) {
			Debug.Log (obj.name);
		}


	}
}
