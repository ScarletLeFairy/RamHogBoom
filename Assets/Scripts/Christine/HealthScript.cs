using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value;  }
    }

	// Use this for initialization
	void Start () {
        isDead = false;
	}
	
	//// Update is called once per frame
	//void Update () {	
	//}

}
