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
	}

	public void SetButtonAppearance(){
		Color colorText = imageButton.color;
		if (canSelectLevel == true) {
				colorText.r = 1;
				colorText.g = 1;
				colorText.b = 1;

		} else if (canSelectLevel == false) {
				colorText.r = 0;
				colorText.g = 0;
				colorText.b = 0;
				
			}
		imageButton.color = colorText;
	}
	public void SaveLevelVariables(){
		PlayerPrefs.SetInt ("CurrentLevel", levelValue);
	}
}
