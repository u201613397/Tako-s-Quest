using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationSoundsControl : MonoBehaviour {

	public AudioClip[] arrayOfClips;
	private AudioSource clipSource;
	// Use this for initialization
	void Start () {
		clipSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayClip(int clipSelected){
		if (clipSource.isPlaying) {
			clipSource.Stop ();
		}
		clipSource.clip = arrayOfClips[clipSelected];
		clipSource.Play ();
	}
}
