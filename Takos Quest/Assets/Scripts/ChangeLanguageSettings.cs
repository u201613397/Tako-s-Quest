using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguageSettings : MonoBehaviour {

	public AllLanguageContainer allLanguageContainer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeLanguage(int language){
		PlayerPrefs.SetInt ("CurrentLanguage", language);
		allLanguageContainer.ApplicateAllLanguageChange (language);
	}
	public void ChangeLanguageByButton(int sign){
		int tmp = PlayerPrefs.GetInt ("CurrentLanguage");
		if (sign == 1) {
			tmp = tmp + 1;
			if (tmp >= allLanguageContainer.maxNumbOfLanguages) {
				tmp = 0;
			}
		}
		if (sign == -1) {
			tmp = tmp - 1;
			if (tmp < 0) {
				tmp = allLanguageContainer.maxNumbOfLanguages - 1;
			}
		}
		PlayerPrefs.SetInt ("CurrentLanguage", tmp);
		allLanguageContainer.ApplicateAllLanguageChange (tmp);
	}
}
