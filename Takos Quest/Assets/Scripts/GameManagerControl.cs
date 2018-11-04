using System.Collections;
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

	[Header("Movements Variables")]
	public Text numbMovementesText;
	public int maxNumbOfMovements;
	public int currentNumbOfMovements;
	public AllEnemyMeleeContainerControl allEnemyMeleeContainer;

	[Header("Time Variables")]
	public Text timeText;
	public float levelTime = 180f;
	public float decreaseTimeSpeed = 1f;
	private int minutes;
	private int seconds;

	[Header("Game State Variables")]
	public bool isGameOver;
	public bool isWin;

	[Header("Win/Lose Condition Variables")]
	public int winCondition;
	public int[] allLoseCondition;

	[Header("Other Variables")]
	public bool isTesting;

	void Awake () {
		GetLevelInformation ();
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

	public void CreatePlayer(int x, int y, float xDistance, float yDistance){
		Vector3 tmpPosition = new Vector3 (x * xDistance, -y * yDistance, 0);
		GameObject tmp = Instantiate (playerToCreate, tmpPosition, transform.rotation);
		player = tmp.GetComponent<PlayerControl> ();
		tmp.GetComponent<PlayerControl> ().playerSoundEffects = playerSoundEffects;
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
			}

		}
	}

	void GetLevelInformation(){
		if (isTesting == false) {
			enemiesToDefeat = PlayerPrefs.GetInt ("EnemiesToDefeat");
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
	public void IncreaseEnemiesDefeated(){
		currentEnemiesDefeat = currentEnemiesDefeat + 1;
		CheckEnemiesDefeated ();
	}
	public void CheckEnemiesDefeated(){
		if (currentEnemiesDefeat >= enemiesToDefeat) {
			isWin = true;
		}
	}
	public void IncreaseMovements(){
		currentNumbOfMovements = currentNumbOfMovements + 1;
		CheckMovements ();
	}
	public void CheckMovements(){
		if (currentNumbOfMovements >= maxNumbOfMovements) {
			isGameOver = true;
		}
	}
}
