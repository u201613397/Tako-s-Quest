using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipConvButtonControl : MonoBehaviour {

	public LoadingControl initScene;
	public LoadingControl finalScene;
	public int currentMomentConversation;
	// Use this for initialization
	void Start () {
		currentMomentConversation = PlayerPrefs.GetInt ("ConversationMoment");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SkipConversation(){
		if (currentMomentConversation == 0) {
			initScene.ActivateLoadingCanvas ();
		} else {
			finalScene.ActivateLoadingCanvas ();
		}
	}
}
