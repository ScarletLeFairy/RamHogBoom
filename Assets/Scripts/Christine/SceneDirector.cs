using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SceneDirector : MonoBehaviour {

    private static List<GameObject> players = new List<GameObject>();
    public static List<GameObject> Players
    {
        get { return players; }
    }

    public static void AddPlayer(GameObject player)
    {
        players.Add(player);
      //  player.GetComponent<PlayerController>().SetJoystickNumber(controls[players.Count - 1]);
    }

    public static void RemovePlayer(GameObject player)
    {
        players.Remove(player);
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
