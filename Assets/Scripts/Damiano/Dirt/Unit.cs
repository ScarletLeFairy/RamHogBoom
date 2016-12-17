using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

	public static List<Unit> units = new List<Unit>();

	void OnEnable(){
		units.Add (this);
	}

	void OnDisable(){
		units.Remove(this);
	}
}
