using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundControl : MonoBehaviour {

	private float soundValue;
	public string typeSoundPref;
	public float maxSoundValue;
	public AudioSource sourceMusic;
	public List<AudioClip> allClipsToPlay;
	public bool canPlayClip;
	// Use this for initialization
	void Awake () {
		//PlayerPrefs.SetFloat (typeSoundPref,1);
		ApplicateChange ();
	}
	void Start(){
		canPlayClip = true;
	}
	// Update is called once per frame
	public void ApplicateChange () {
		soundValue = PlayerPrefs.GetFloat (typeSoundPref);
		sourceMusic.volume = soundValue * maxSoundValue;
	}
	public void PlayClip(int pos){
		if (canPlayClip == true) {
			sourceMusic.clip = allClipsToPlay[pos];
			sourceMusic.Play ();
		}
	}
}
