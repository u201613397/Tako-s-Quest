using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelButtonControl : MonoBehaviour {

	public int levelValue;
	public Text levelText;
	private Image imageButton;

	public int[] requirementLevelToPlay;
	public bool canSelectLevel;
	public string levelStatePlayerPref;

	[Header("Conversation Variables")]
	public int haveInitialConversation;
	public int haveFinalConversation;
	public LoadingControl storyScene;
	public LoadingControl gameplayScene;

	[Header("Level Information Variables")]
	public float timeToReachLevel;
	public int numbOfEnemiesToDefeat;
	public int maxNumbOfMovements;

	public int winCondition;
	public int[] allLoseCondition;

	[Header("Sound Variables")]
	public PlaySoundControl allSounds;

	[Header("Stars Variables")]
	public StarsContainerControl starsContainer;
	// Use this for initialization
	void Awake () {
		imageButton = GetComponent<Image> ();
		//SetInitialValues ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetInitialValues(int i){
		levelValue = i;
		string tmp = "";
		if (levelValue < 10) {
			tmp = "0";
		}
		levelText.text = tmp + levelValue.ToString ();
	}
	public void CalculateLevelState(){
		int tmp = 0;
		if (requirementLevelToPlay.Length > 0) {
			for (int i = 0; i < requirementLevelToPlay.Length; i++) {
				levelStatePlayerPref = "Level" + requirementLevelToPlay [i].ToString () + "Passed";
				tmp = PlayerPrefs.GetInt (levelStatePlayerPref);
				if (tmp == 1) {
					break;
				}
			}
		} else {
			tmp = 1;
		}
		if (tmp == 0) {
			canSelectLevel = false;
		} else {
			canSelectLevel = true;
		}
		SetButtonAppearance ();
		//CalculateStars ();
	}
	public void CalculateStars(){
		starsContainer.CheckForStars (levelValue);
	}
	public void SetButtonAppearance(){
		Color colorText = imageButton.color;
		if (canSelectLevel == true) {
				colorText.r = 1;
				colorText.g = 1;
				colorText.b = 1;

		} else if (canSelectLevel == false) {
				colorText.r = 0.5f;
				colorText.g = 0.5f;
				colorText.b = 0.5f;
				
			}
		imageButton.color = colorText;
	}
	public void SaveLevelVariables(){
		if (canSelectLevel == true) {
			allSounds.PlayClip (0);
			PlayerPrefs.SetInt ("ConversationMoment", 0);
			PlayerPrefs.SetInt ("CurrentLevel", levelValue);
			PlayerPrefs.SetInt ("InitialStoryConversation", haveInitialConversation);
			PlayerPrefs.SetInt ("FinalStoryConversation", haveFinalConversation);

			PlayerPrefs.SetInt ("EnemiesToDefeat", numbOfEnemiesToDefeat);
			PlayerPrefs.SetFloat ("LevelTime", timeToReachLevel);
			PlayerPrefs.SetInt ("MaxNumbOfMovements", maxNumbOfMovements);

			PlayerPrefs.SetInt ("WinCondition", winCondition);
			for (int i = 0; i < allLoseCondition.Length; i++) {
				string tmp = "LoseCondition" + (i + 1).ToString ();
				PlayerPrefs.SetInt (tmp, allLoseCondition[i]);
			}
			PlayerPrefs.SetInt ("NumbOfLoseConditions", allLoseCondition.Length);

			if (haveInitialConversation == 0) {
				gameplayScene.ActivateLoadingCanvas ();
			} else {
				storyScene.ActivateLoadingCanvas ();
			}
		} else {
			allSounds.PlayClip (1);
		}
	}
}
