using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombControl : MonoBehaviour {

	[Header("Enemy Movement Variables")]
	public int xDirection = 0;
	public int yDirection = 0;
	public int typeOfMovement;
	private Rigidbody2D rbEnemy;
	public float speedMovement;

	[Header("Enemy Detector Variables")]
	public List<DetectGroundControl> allGroundDetectors;

	[Header("Enemy Container Variables")]
	public AllEnemyBombContainerControl enemyBombContainer;
	// Use this for initialization
	void Awake () {
		rbEnemy = GetComponent<Rigidbody2D> ();
		//SetInitialVariables ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}
	void FixedUpdate () {
		
	}
	void Movement(){
		switch (typeOfMovement) {
		case 0:
			rbEnemy.position = new Vector2 (rbEnemy.position.x + speedMovement * xDirection * Time.deltaTime, 0);
			break;
		case 1:
			rbEnemy.position = new Vector2 (0, rbEnemy.position.y + speedMovement * yDirection * Time.deltaTime);
			break;
		case 2:
			rbEnemy.position = new Vector2 (rbEnemy.position.x + speedMovement * xDirection * Time.deltaTime,
				rbEnemy.position.y + speedMovement * yDirection * Time.deltaTime);
			break;
		}
	}
	public void SetInitialVariables(int movType){
		typeOfMovement = movType;
		switch (typeOfMovement) {
		case 0:
			xDirection = 1;
			yDirection = 0;
			rbEnemy.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			allGroundDetectors [0].canDetectTag = true;
			allGroundDetectors [1].canDetectTag = true;
			allGroundDetectors [2].canDetectTag = false;
			allGroundDetectors [3].canDetectTag = false;
			allGroundDetectors [2].gameObject.SetActive (false);
			allGroundDetectors [3].gameObject.SetActive (false);
			break;
		case 1:
			xDirection = 0;
			yDirection = 1;
			rbEnemy.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			allGroundDetectors [0].canDetectTag = false;
			allGroundDetectors [1].canDetectTag = false;
			allGroundDetectors [0].gameObject.SetActive (false);
			allGroundDetectors [1].gameObject.SetActive (false);
			allGroundDetectors [2].canDetectTag = true;
			allGroundDetectors [3].canDetectTag = true;
			break;
		case 2:
			xDirection = 1;
			yDirection = 0;
			rbEnemy.constraints = RigidbodyConstraints2D.FreezeRotation;
			allGroundDetectors [0].canDetectTag = false;
			allGroundDetectors [1].canDetectTag = true;
			allGroundDetectors [2].canDetectTag = false;
			allGroundDetectors [3].canDetectTag = false;
			break;
		}
	}
	public void ChangeDirection(DetectGroundControl detector){
		switch (typeOfMovement) {
		case 0:
			xDirection = xDirection * -1;
			detector.ActivateDetector (2);
			break;
		case 1:
			yDirection = yDirection * -1;
			detector.ActivateDetector (2);
			break;
		case 2:
			int tmpX = 0;
			int tmpY = 0;
			// 0: LEFT 1: RIGHT 2: TOP 3: DOWN
			if (xDirection == 1 && yDirection == 0) {
				tmpX = 0;
				tmpY = 1;
				allGroundDetectors [1].canDetectTag = false;
				allGroundDetectors [2].canDetectTag = true;
			}
			if (xDirection == -1 && yDirection == 0) {
				tmpX = 0;
				tmpY = -1;
				allGroundDetectors [0].canDetectTag = false;
				allGroundDetectors [3].canDetectTag = true;
			}
			if (xDirection == 0 && yDirection == 1) {
				tmpX = -1;
				tmpY = 0;
				allGroundDetectors [2].canDetectTag = false;
				allGroundDetectors [0].canDetectTag = true;
			}
			if (xDirection == 0 && yDirection == -1) {
				tmpX = 1;
				tmpY = 0;
				allGroundDetectors [1].canDetectTag = true;
				allGroundDetectors [3].canDetectTag = false;
			}
			xDirection = tmpX;
			yDirection = tmpY;
			//detector.ActivateDetector (2);
			break;
		}
	}
}
