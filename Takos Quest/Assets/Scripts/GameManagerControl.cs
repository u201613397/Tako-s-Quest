﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerControl : MonoBehaviour {


	[Header("Player Variables")]
	public GameObject playerToCreate;
	public PlayerControl player;
	public PlaySoundControl playerSoundEffects;

	[Header("Enemies Variables")]
	public Text enemiesDeadsText;
	public int enemiesToDefeat;
	public int currentEnemiesDefeat;
	public AllEnemyMeleeContainerControl allEnemyMeleeContainer;
	public AllEnemyBombContainerControl allEnemyBombContainer;

	[Header("Trap Variables")]
	public AllDeathTrapContainer allDeathTrapContainer;

	[Header("Block Variables")]
	public AllChangeDirectionBlockContainer allChangeDirectionBlockContainer;

	[Header("Movements Variables")]
	public Text numbMovementesText;
	public int maxNumbOfMovements;
	public int currentNumbOfMovements;

	[Header("Time Variables")]
	public Text timeText;
	private float initialTime;
	public float levelTime = 180f;
	public float decreaseTimeSpeed = 1f;
	private int minutes;
	private int seconds;

	[Header("Game State Variables")]
	public bool isGameOver;
	public bool isWin;
	public int currentLevel; 

	[Header("Win/Lose Condition Variables")]
	public int winCondition;
	public int[] allLoseCondition;

	[Header("Scenes Variables")]
	public LoadingControl conversationScene;
	public LoadingControl mapScene;
	public LoadingControl gameplayScene;

	[Header("Other Variables")]
	public bool isTesting;
	public GameObject handTutorial;

	void Awake () {
		GetLevelInformation ();
		CheckMovements ();
		CheckEnemiesDefeated ();
		//RandomDivision ();
	}
	public void RandomDivision(){
		int val = 15000;
		int intervals = 3;
		int first = Random.Range (0, val / intervals);
		int second = Random.Range (0, val / intervals);
		int third = 15000 - first - second;
		print (first);
		print (second);
		print (third);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CalculatePassedTime ();
	}

	public void SendCreateEnemyMelee(int x, int y, float xDistance, float yDistance){
		allEnemyMeleeContainer.CreateEnemyMelee (x, y, xDistance, yDistance);
	}

	public void SendCreateEnemyBomb(int x, int y, float xDistance, float yDistance, int typeOfMovement){
		allEnemyBombContainer.CreateEnemyBomb (x, y, xDistance, yDistance, typeOfMovement);
		//print ("entra al game manager");
	}

	public void SendCreateDeathTrap(int x, int y, float xDistance, float yDistance){
		allDeathTrapContainer.CreateDeathTrap (x, y, xDistance, yDistance);
	}

	public void SendCreateChangeDirectionBlock(int x, int y, float xDistance, float yDistance){
		allChangeDirectionBlockContainer.CreateChangeDirectionBlock (x, y, xDistance, yDistance);
	}

	public void CreatePlayer(int x, int y, float xDistance, float yDistance){
		Vector3 tmpPosition = new Vector3 (x * xDistance, -y * yDistance, 0);
		GameObject tmp = Instantiate (playerToCreate, tmpPosition, transform.rotation);
		player = tmp.GetComponent<PlayerControl> ();
		tmp.GetComponent<PlayerControl> ().playerSoundEffects = playerSoundEffects;
		tmp.GetComponent<PlayerControl> ().gmManager = this.gameObject.GetComponent<GameManagerControl>();//04-11-2018 INCREMENTAR NÚMERO DE MOVIMIENTOS
	}

	void CalculatePassedTime(){
		if (isGameOver == false && isWin == false) {
			levelTime = levelTime - decreaseTimeSpeed * Time.deltaTime;
			minutes = (int)levelTime / 60;
			seconds = (int)levelTime % 60;
			string minutesString;
			string secondsString;
			if (minutes < 10) {
				minutesString = "0" + minutes.ToString ("0");
			} else {
				minutesString = minutes.ToString ("0");
			}
			if (seconds < 10) {
				secondsString = "0" + seconds.ToString ("0");
			} else {
				secondsString = seconds.ToString ("0");
			}
			timeText.text = minutesString + ":" + secondsString;

			if (levelTime < 0) {
				levelTime = 0f;
				isGameOver = true;
				CheckGameState ();
			}

		}
	}

	void CalculateStarsToSave(){
		int starsToSave = 0;
		if (levelTime >= initialTime) {
			starsToSave = 3;
		}
		if (levelTime <= initialTime && levelTime >= initialTime * 2 / 3) {
			starsToSave = 3;
		}
		if (levelTime < initialTime * 2 / 3 && levelTime >= initialTime / 3) {
			starsToSave = 2;
		}
		if (levelTime < initialTime / 3) {
			starsToSave = 1;
		}
		string tmp = "Level" + currentLevel.ToString () + "StarsEarned";
		int starsPrevious = PlayerPrefs.GetInt (tmp);
		if (starsPrevious < starsToSave) {
			PlayerPrefs.SetInt (tmp, starsToSave);
		}
		//print ("Estrellas ganadas nivel: " + currentLevel + " son " + starsToSave);
		//print ("Estrellas previas nivel: " + currentLevel + " son " + starsPrevious);
	}

	void GetLevelInformation(){
		if (isTesting == false) {
			currentLevel = PlayerPrefs.GetInt ("CurrentLevel");
			if (currentLevel == 1) {
				handTutorial.gameObject.SetActive (true);
			}
			enemiesToDefeat = PlayerPrefs.GetInt ("EnemiesToDefeat");
			initialTime = levelTime;
			levelTime = PlayerPrefs.GetFloat ("LevelTime");
			maxNumbOfMovements = PlayerPrefs.GetInt ("MaxNumbOfMovements");

			winCondition = PlayerPrefs.GetInt ("WinCondition");
			int tmpLoseConditions = PlayerPrefs.GetInt ("NumbOfLoseConditions");
			allLoseCondition = new int[tmpLoseConditions];
			for (int i = 0; i < tmpLoseConditions; i++) {
				string tmp = "LoseCondition" + (i + 1).ToString ();
				allLoseCondition[i] = 	PlayerPrefs.GetInt (tmp, allLoseCondition[i]);
			}
		}
	}
	public void OcultHandTutorial(){
		handTutorial.gameObject.SetActive (false);
	}
	public void IncreaseEnemiesDefeated(){
		//print ("entra");
		currentEnemiesDefeat = currentEnemiesDefeat + 1;
		CheckEnemiesDefeated ();
	}
	public void CheckEnemiesDefeated(){
		enemiesDeadsText.text = currentEnemiesDefeat.ToString () + "/" + enemiesToDefeat.ToString ();
		if (currentEnemiesDefeat >= enemiesToDefeat && winCondition == 1) {
			isWin = true;
			CheckGameState ();
		}
	}
	public void IncreaseMovements(){
		currentNumbOfMovements = currentNumbOfMovements + 1;
		CheckMovements ();
	}
	public void CheckMovements(){
		string tmp = "";
		if (maxNumbOfMovements != 0) {
			tmp = maxNumbOfMovements.ToString ();
		} else {
			tmp = "-";
		}
		numbMovementesText.text = currentNumbOfMovements.ToString () + "/" + tmp;
		if (currentNumbOfMovements >= maxNumbOfMovements && maxNumbOfMovements != 0) {
			isGameOver = true;
			CheckGameState ();
		}
	}
	public void CheckGameState(){
		if (isWin == true) {
			CalculateStarsToSave ();
			int level = PlayerPrefs.GetInt ("CurrentLevel");
			string passedLevelPref = "Level" + level.ToString () + "Passed";
			PlayerPrefs.SetInt (passedLevelPref, 1);
			int tmp = PlayerPrefs.GetInt ("FinalStoryConversation");
			if (tmp == 0) {
				mapScene.ActivateLoadingCanvas ();
			} else {
				PlayerPrefs.SetInt ("ConversationMoment", 1);
				conversationScene.ActivateLoadingCanvas ();
			}	
		}
		if (isGameOver == true) {
			gameplayScene.ActivateLoadingCanvas ();
		}
	}
}
