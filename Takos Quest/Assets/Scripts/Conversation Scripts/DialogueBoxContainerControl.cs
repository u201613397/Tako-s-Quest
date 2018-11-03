using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueBoxContainerControl : MonoBehaviour {

	public Text emisorText;
	public Text emisorTextRememberConversation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SelectEmisor(int currentCharacter){
		switch (currentCharacter) {
		case 0:
			emisorText.text = "Tako";
			emisorTextRememberConversation.text = "Tako";
			break;
		case 1:
			emisorText.text = "Yaki";
			emisorTextRememberConversation.text = "Yaki";
			break;
		}
	}
}
