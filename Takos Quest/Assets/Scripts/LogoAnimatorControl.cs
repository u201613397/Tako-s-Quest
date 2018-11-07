using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogoAnimatorControl : MonoBehaviour {

	private Animator logoAnimator;
	public float timeToDoNextAnim;

	private float timerTmp;

	private bool countTimer;

	public string SceneToLoad;

	public float timeToChargueScene;

	//AsyncOperation operationAsync;//07-03-2018 ESPERAR A QUE CARGUE
	// Use this for initialization
	void Start () {
		logoAnimator = GetComponent<Animator> ();
		countTimer = true;
		PlayerPrefs.SetInt ("MusicValue", 1);//28-04-2017
		PlayerPrefs.SetInt ("SoundsValue", 1);//28-04-2017    
		//PlayerPrefs.SetInt("CurrentCoins",50000);
		//VideoBuild();
	}

	// Update is called once per frame
	void Update () {
		if(countTimer == true){
			timerTmp = timerTmp + Time.deltaTime;

		}
		if(timerTmp >= timeToDoNextAnim){
			countTimer = false;
			timerTmp = 0f;
			logoAnimator.SetBool ("isAppear", true);
		}
	}
	public void WaitForDisappear(){
		//	countTimer = true;
		Invoke ("Disappear", timeToDoNextAnim);
	}
	void Disappear(){
		logoAnimator.SetBool ("isDisappear", true);
	}
	public void WaitForChangueScene(){
		Invoke ("LoadScene", timeToChargueScene);
	}
	public void LoadScene(){
		SceneManager.LoadScene (SceneToLoad);
		//StartCoroutine (LoadLevelWithRealProgress ());//07-03-2018 ESPERAR A QUE CARGUE
	}

	public void VideoBuild(){
		PlayerPrefs.SetInt ("RouletteIntents",20);
		PlayerPrefs.SetInt("CurrentCoins",50000);
		PlayerPrefs.SetInt("Photo1",1);
		PlayerPrefs.SetInt("Photo2",1);
		PlayerPrefs.SetInt("Photo3",1);
		PlayerPrefs.SetInt ("CurrentLevel", 26);
		PlayerPrefs.SetInt ("MaxLevelAvailable",26);
		PlayerPrefs.SetInt ("CurrentSpecialLevel",3);
		PlayerPrefs.SetInt ("MaxSpecialLevelAvailable",5);
		PlayerPrefs.SetInt("Level1Stars",3);
		PlayerPrefs.SetInt("Level2Stars",3);
		PlayerPrefs.SetInt("Level3Stars",3);
		PlayerPrefs.SetInt("Level4Stars",3);
		PlayerPrefs.SetInt("Level5Stars",3);
		PlayerPrefs.SetInt("Level6Stars",3);
		PlayerPrefs.SetInt("Level7Stars",3);
		PlayerPrefs.SetInt("Level8Stars",3);
		PlayerPrefs.SetInt("Level9Stars",3);
		PlayerPrefs.SetInt("Level10Stars",3);
		PlayerPrefs.SetInt("Level11Stars",3);
		PlayerPrefs.SetInt("Level12Stars",3);
		PlayerPrefs.SetInt("Level13Stars",3);
		PlayerPrefs.SetInt("Level14Stars",3);
		PlayerPrefs.SetInt("Level15Stars",3);
		PlayerPrefs.SetInt("Level16Stars",3);
		PlayerPrefs.SetInt("Level17Stars",3);
		PlayerPrefs.SetInt("Level18Stars",3);
		PlayerPrefs.SetInt("Level19Stars",3);
		PlayerPrefs.SetInt("Level20Stars",3);
		PlayerPrefs.SetInt("Level21Stars",3);
		PlayerPrefs.SetInt("Level22Stars",3);
		PlayerPrefs.SetInt("Level23Stars",3);
		PlayerPrefs.SetInt("Level24Stars",3);
		PlayerPrefs.SetInt("Level25Stars",3);
		PlayerPrefs.SetInt("Level26Stars",3);
		PlayerPrefs.SetInt("Item1Quantity",20);
		PlayerPrefs.SetInt("Item2Quantity",20);
		PlayerPrefs.SetInt("Item3Quantity",20);
		PlayerPrefs.SetInt("Item4Quantity",20);
		PlayerPrefs.SetInt("Item5Quantity",20);
		PlayerPrefs.SetInt("Item6Quantity",20);
		PlayerPrefs.SetInt("Item7Quantity",20);
		PlayerPrefs.SetInt("Item8Quantity",20);
		PlayerPrefs.SetInt ("SpecialLevel1Stars",3);
		PlayerPrefs.SetInt ("SpecialLevel2Stars",3);
		PlayerPrefs.SetInt ("SpecialLevel3Stars",3);
		PlayerPrefs.SetInt ("SpecialLevel4Stars",3);
		PlayerPrefs.SetInt ("SpecialLevel5Stars",3);
		PlayerPrefs.SetInt ("FirstRouletteAcces",1);
		PlayerPrefs.SetInt ("FirstDailyRewardAccess",1);
		PlayerPrefs.SetInt ("FirstTimeShopCloth",1);
	}
	/*
	IEnumerator LoadLevelWithRealProgress(){//07-03-2018 ESPERAR A QUE CARGUE
		yield return new WaitForSecondsRealtime (1);
		operationAsync = SceneManager.LoadSceneAsync (SceneToLoad);
		Time.timeScale = 1;
		while (!operationAsync.isDone) {
			yield return null;
			//barFillImage.fillAmount = operationAsync.progress; //NO SE SABE SI HABRÁ UNA BARRA
		}
	}//07-03-2018 ESPERAR A QUE CARGUE
*/
}
