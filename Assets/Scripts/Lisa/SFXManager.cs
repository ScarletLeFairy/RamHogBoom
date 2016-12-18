using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	public class SFXManager : MonoBehaviour
	{
		public AudioClip[] Sounds;
		public int Index;

		private static float volume;

		public void ChangeAudioVolume(Slider volumeSlider){
			SFXManager.volume = volumeSlider.value;
		}

		//delete unused audio sources
		private void CleanUpAudioSources(GameObject gameObject){
			AudioSource[] sources = gameObject.GetComponents<AudioSource> ();
			if (sources != null) {
				foreach(AudioSource source in sources){
					if (!source.isPlaying) {
						Destroy (source);
					}
				}
			}
		}

		//plays sound from game object adds sources as needed
		private void PlaySound(GameObject gameObject){
			AudioSource audio = gameObject.GetComponent<AudioSource> ();
			if (audio == null || audio.isPlaying) {
				audio = gameObject.AddComponent<AudioSource> ();
			}
			audio.PlayOneShot (Sounds [Index], volume);
			CleanUpAudioSources(gameObject);
		}

		//plays a given sound at an position
		public void PlaySFXAtGameObject(int index, GameObject gameObject){
			if (index < Sounds.Length && index > 0) {
				Index = index;
				PlaySound (gameObject);
			}
		}

		//plays the Next SFX contained in Sounds
		public void PlayNextSFXAtGameObject(GameObject gameObject){
			if (Index + 1 < Sounds.Length) {
				Index++;
				PlaySound (gameObject);
			} else {
				Index = 0;
				PlaySound (gameObject);
			}
		}
	}
}

