using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationMomentControl : MonoBehaviour {

	public int momentOfConversation;
	public GameObject[] allConversations;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("ConversationMoment",1);//21-12-2017 SETEAR CONVERSACION FINAL
		momentOfConversation = PlayerPrefs.GetInt ("ConversationMoment");
		SelectConversation ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SelectConversation(){
		allConversations [momentOfConversation].gameObject.SetActive (true);
	}
}
