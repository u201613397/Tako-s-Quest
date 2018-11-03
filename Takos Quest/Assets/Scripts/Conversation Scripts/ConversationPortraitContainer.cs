using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationPortraitContainer : MonoBehaviour {

	public ConversationPortraitControl[] allPosiblePortraits;
	public int currentCharacterSelected = -1;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void ChangePortrait(int numbOfCharacter, int numbOfPos, int numbOfAnimation){
		if (currentCharacterSelected != numbOfCharacter) {
			allPosiblePortraits [currentCharacterSelected].DisappearPortrait ();
		}
		currentCharacterSelected = numbOfCharacter;
		allPosiblePortraits [numbOfCharacter].AppearPortrait (numbOfPos, numbOfAnimation);
	}
}

