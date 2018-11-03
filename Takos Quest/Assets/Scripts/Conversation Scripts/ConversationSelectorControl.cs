using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationSelectorControl : MonoBehaviour {

	public int currentLevel;
	public GameObject[] allConversations;
	public bool thisIsSpecialMap;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("CurrentLevel", 1);
		if (thisIsSpecialMap == false) {
			currentLevel = PlayerPrefs.GetInt ("CurrentLevel") - 1;
		} else {
			currentLevel = PlayerPrefs.GetInt ("CurrentSpecialLevel") - 1;
		}
		SelectConversation ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SelectConversation(){
		allConversations [currentLevel].gameObject.SetActive (true);
	}
}
