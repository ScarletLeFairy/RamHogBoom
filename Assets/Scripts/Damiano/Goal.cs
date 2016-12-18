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

	void OnTriggerEnter(Collider other){

		GameObject obj = other.transform.root.gameObject;
		Player player = obj.GetComponent<Player> ();

		Debug.Log (other.gameObject.name);

		if (player != null && player.faction != faction) {
			Debug.Log (obj.name);
		}


	}
}
