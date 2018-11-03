using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundConversationControl : MonoBehaviour {

	public ConversationSelectorControl conversationLevel;
	public Sprite[] allSprites;
	private SpriteRenderer currenSprite;
	public int currentImage;
	// Use this for initialization
	void Start () {
		currenSprite = GetComponent<SpriteRenderer> ();
		SetImage ();
	}

	// Update is called once per frame
	void Update () {

	}
	public void SetImage(){
		int momentOfConversation = PlayerPrefs.GetInt ("ConversationMoment");
		if (momentOfConversation == 0) {
			currentImage = PlayerPrefs.GetInt ("SpriteConversation");
			currenSprite.sprite = allSprites [currentImage];
		} else if (momentOfConversation == 1){
			currentImage = PlayerPrefs.GetInt ("SpriteConversationAfterGameplay");
			currenSprite.sprite = allSprites [currentImage];
		}
	}
}