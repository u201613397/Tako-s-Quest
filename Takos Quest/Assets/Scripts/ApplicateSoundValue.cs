using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicateSoundValue : MonoBehaviour {

	private float soundValue;
	public string typeSoundPref;
	public float maxSoundValue;
	public AudioSource sourceMusic;
	public AudioClip clipToPlay;
	public bool canPlayClip;
	// Use this for initialization
	void Awake () {
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
	public void PlayClip(){
		if (canPlayClip == true) {
			sourceMusic.clip = clipToPlay;
			sourceMusic.Play ();
		}
	}
}
