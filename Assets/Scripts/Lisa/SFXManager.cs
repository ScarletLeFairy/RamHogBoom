using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	public class SFXManager : MonoBehaviour
	{
		public AudioClip[] Sounds;
		public Slider VolumeSlider;
		public int Index;

		//plays a given sound at an position
		public void PlaySFXAtGameObject(int index, GameObject gameObject){
			if (index < Sounds.Length && index > 0) {
				Index = index;
				AudioSource.PlayClipAtPoint (Sounds [index], gameObject.transform.position);
			}
		}

		//plays the Next SFX contained in Sounds
		public void PlayNextSFXAtGameObject(GameObject gameObject){
			if (Index + 1 < Sounds.Length) {
				AudioSource.PlayClipAtPoint (Sounds [++Index], gameObject.transform.position);
			} else {
				AudioSource.PlayClipAtPoint (Sounds [++Index], gameObject.transform.position);
			}
		}
	}
}

