using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource Source;
	public AudioClip[] Sounds;
	public Slider VolumeSlider;
	public int Index;
	public float DefaultVolume;
	public bool isSFX;

	// Use this for initialization
	void Start () {
		Source.loop = !isSFX;
		ChangeAudioVolume (DefaultVolume);
		if (!Source.isPlaying && !isSFX ) {
			Source.Play ();
		}
	}

	public void PlaySFX(int index){
		ChangeMusicTrack (index);
		Source.Play ();
	}

	public void ChangeAudioVolume(){
		Source.volume = VolumeSlider.value;
	}

	public void ChangeAudioVolume(float volume){
		Source.volume = volume;
		VolumeSlider.value = volume;
	}

	public void ChangeMusicTrack(string trackName){
		Source.clip = Resources.Load<AudioClip>(trackName);
	}

	public void ChangeMusicTrack(int index){
		if (index < Sounds.Length && index > 0) {
			Source.clip = Sounds[index];
		}
	}

	public void SkipToNextTrack(){
		if (++Index < Sounds.Length) {
			Source.clip = Sounds [Index];
		} else {
			Index = 0;
			Source.clip = Sounds [Index];
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
