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
	// Use this for initialization
	void Awake () {
		rbEnemy = GetComponent<Rigidbody2D> ();
		SetInitialVariables ();
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
			//print (xDirection);
			break;
		}
	}
	void SetInitialVariables(){
		switch (typeOfMovement) {
		case 0:
			xDirection = 1;
			rbEnemy.constraints = RigidbodyConstraints2D.FreezePositionY;
			allGroundDetectors [0].canDetectTag = true;
			allGroundDetectors [1].canDetectTag = true;
			allGroundDetectors [2].canDetectTag = false;
			allGroundDetectors [3].canDetectTag = false;
			allGroundDetectors [2].gameObject.SetActive (false);
			allGroundDetectors [3].gameObject.SetActive (false);
			break;
		}
	}
	public void ChangeDirection(DetectGroundControl detector){
		switch (typeOfMovement) {
		case 0:
			xDirection = xDirection * -1;
			detector.ActivateDetector (2);
			//print ("Cambia la puta dirección");
			//print (xDirection);
			break;
		}
	}
}
