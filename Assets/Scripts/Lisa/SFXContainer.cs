using UnityEngine;
using System.Collections;

public class SFXContainer : MonoBehaviour {

	public static SFXManager ExplosionSFX, HitSFX, ThunderSFX, FallingSFX;
	public GameObject SFX;

	// Use this for initialization
	void Start () {
		SFXManager[] managers = SFX.GetComponentsInChildren<SFXManager> ();
		foreach(SFXManager manager in managers){
			Debug.Log (manager.name);
			if (manager.name == "Explosion SFX") {
				ExplosionSFX = manager;
			} else if (manager.name == "Hit SFX") {
				HitSFX = manager;
			} else if (manager.name == "Thunder SFX") {
				ThunderSFX = manager;
			} else if (manager.name == "Falling SFX") {
				FallingSFX = manager;
			}
		}
	}
}
