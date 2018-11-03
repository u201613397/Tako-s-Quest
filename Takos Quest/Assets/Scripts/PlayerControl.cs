using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speedMovement;
	public int xDirection;
	public int yDirection;
	private Rigidbody2D rbPlayer;

	public float horizontal;
	public float vertical;

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	public float swipeSensibility = 20f;//15-09-2018
	public bool detectSwipeOnlyAfterRelease = false;//15-09-2018

	public bool isGrounded = true;

	public List<BoxCollider2D> allDirectionalColliders;
	public BoxCollider2D currentDetectorCollider;

	[Header("Detect Walls Variables")]
	public LayerMask whatIsGround;//04-09-2018 LAYER DE LOS MUROS
	//public Transform groundCheck;
	public List<Transform> allDirectionalGroundChecks;//04-09-2018 DETECTOR PARA TODAS LAS DIRECCIONES
	public bool isLeftGrounded;//04-09-2018
	public bool isRightGrounded;//04-09-2018
	public bool isUpGrounded;//04-09-2018
	public bool isDownGrounded;//04-09-2018
	private int groundLayer;//04-09-2018 NUMERO DE LAYER DE LOS MUROS

	public int currentDirectionDetector;//08-09-2018 EVITAR CAMBIAR DIRECCION

	[Header("Sound Variables")]
	public PlaySoundControl playerSoundEffects;//15-09-2018
	// Use this for initialization
	void Start () {
		rbPlayer = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//PlayerMovement ();
		MouseSwipe ();
		/*
		#if UNITY_EDITOR
		MouseSwipe ();
		#endif

		#if UNITY_ANDROID
		TouchSwipe();
		#endif
*/
		CheckWalls ();
	}

	public void PlayerMovement(){
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		rbPlayer.velocity = new Vector2 (horizontal * speedMovement, vertical* speedMovement);
	}


	public void MouseSwipe(){
		if (Input.GetMouseButtonDown (0)) {
			//save began touch 2d point
			firstPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			secondPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		}

		if (Input.GetMouseButtonUp (0)) {
			secondPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			CheckSwipe ();
		}
		rbPlayer.velocity = new Vector2 (xDirection * speedMovement, yDirection * speedMovement);
	}

	public void TouchSwipe(){
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				firstPressPos = touch.position;
				secondPressPos = touch.position;
			}

			//Detects Swipe while finger is still moving
			if (touch.phase == TouchPhase.Moved) {
				if (!detectSwipeOnlyAfterRelease) {
					secondPressPos = touch.position;
					CheckSwipe ();
				}
			}

			//Detects swipe after finger is released
			if (touch.phase == TouchPhase.Ended) {
				secondPressPos = touch.position;
				CheckSwipe ();
			}
		}
		rbPlayer.velocity = new Vector2 (xDirection * speedMovement, yDirection * speedMovement);
	}


	void CheckSwipe(){//15-09-2018
		//Check if Vertical swipe
		if (VerticalMove () > swipeSensibility && VerticalMove () > HorizontalValMove ()) {
			//Debug.Log("Vertical");
			if (secondPressPos.y - firstPressPos.y > 0) {//up swipe
				if (isUpGrounded == false && isGrounded == true) {
					OnSwipeUp ();
				}
			} else if (secondPressPos.y - firstPressPos.y < 0) {//Down swipe
				if (isDownGrounded == false && isGrounded == true) {
					OnSwipeDown ();
				}
			}
			firstPressPos = secondPressPos;
		} else if (HorizontalValMove () > swipeSensibility && HorizontalValMove () > VerticalMove ()) {//Check if Horizontal swipe
			//Debug.Log("Horizontal");
			if (secondPressPos.x - firstPressPos.x > 0) {//Right swipe
				if (isRightGrounded == false && isGrounded == true) {
					OnSwipeRight ();
				}
			} else if (secondPressPos.x - firstPressPos.x < 0) {//Left swipe
				if (isLeftGrounded == false && isGrounded == true) {
					OnSwipeLeft ();
				}
			}
			firstPressPos = secondPressPos;
		} else {//No Movement at-all
			//Debug.Log("No Swipe!");
		}
	}

	float VerticalMove(){
		return Mathf.Abs(secondPressPos.y - firstPressPos.y);
	}

	float HorizontalValMove(){
		return Mathf.Abs(secondPressPos.x - firstPressPos.x);
	}

	void OnSwipeUp(){
		Debug.Log("Swipe UP");
		xDirection = 0;
		yDirection = 1;
		isGrounded = false;
		currentDirectionDetector = 1;//08-09-2018 EVITAR CAMBIAR DIRECCION
		rbPlayer.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; 
	}
	void OnSwipeDown(){
		Debug.Log("Swipe DOWN");
		xDirection = 0;
		yDirection = -1;
		isGrounded = false;
		currentDirectionDetector = 2;//08-09-2018 EVITAR CAMBIAR DIRECCION
		rbPlayer.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; 
	}
	void OnSwipeLeft(){
		Debug.Log("Swipe LEFT");
		xDirection = -1;
		yDirection = 0;
		isGrounded = false;
		currentDirectionDetector = 3;//08-09-2018 EVITAR CAMBIAR DIRECCION
		rbPlayer.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
	}
	void OnSwipeRight(){
		Debug.Log("Swipe RIGHT");
		xDirection = 1;
		yDirection = 0;
		isGrounded = false;
		currentDirectionDetector = 4;//08-09-2018 EVITAR CAMBIAR DIRECCION
		rbPlayer.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
	}
		
	public void CheckWalls(){//04-09-2018 DETECTAR PAREDES
		isUpGrounded = Physics2D.Linecast (this.transform.position, allDirectionalGroundChecks[0].position, whatIsGround);
		RaycastHit2D hitInfoUp = Physics2D.Linecast (transform.position, allDirectionalGroundChecks[0].transform.position,whatIsGround);

		/*
		if (hitInfoUp.collider != null) {//21-06-2016
			verticalSpeed = 0;//21-06-2016
		}//21-06-2016
		*/

		isDownGrounded = Physics2D.Linecast (this.transform.position, allDirectionalGroundChecks[1].position, whatIsGround);
		RaycastHit2D hitInfoDown = Physics2D.Linecast (transform.position, allDirectionalGroundChecks[1].transform.position,whatIsGround);

		isLeftGrounded = Physics2D.Linecast (this.transform.position, allDirectionalGroundChecks[2].position, whatIsGround);
		RaycastHit2D hitInfoLeft = Physics2D.Linecast (transform.position, allDirectionalGroundChecks[2].transform.position,whatIsGround);

		isRightGrounded = Physics2D.Linecast (this.transform.position, allDirectionalGroundChecks[3].position, whatIsGround);
		RaycastHit2D hitInfoRight = Physics2D.Linecast (transform.position, allDirectionalGroundChecks[3].transform.position,whatIsGround);

		switch (currentDirectionDetector) {
		case 1:
			if (hitInfoUp.collider != null) {
				isGrounded = true;
			}
			break;
		case 2:
			if (hitInfoDown.collider != null) {
				isGrounded = true;
			}
			break;
		case 3:
			if (hitInfoLeft.collider != null) {
				isGrounded = true;
			}
			break;
		case 4:
			if (hitInfoRight.collider != null) {
				isGrounded = true;
			}
			break;
		}
		/*
		isGrounded = Physics2D.Linecast (this.transform.position, groundCheck.position, whatIsGround);
		RaycastHit2D hitInfo = Physics2D.Linecast (transform.position, groundCheck.transform.position,whatIsGround);
*/
	}//04-09-2018 DETECTAR PAREDES

	public void DetectEndMovement(){
		switch (currentDirectionDetector) {
		case 0:
			isGrounded = isUpGrounded;
			break;
		case 1:
			isGrounded = isDownGrounded;
			break;
		case 2:
			isGrounded = isLeftGrounded;
			break;
		case 3:
			isGrounded = isRightGrounded;
			break;
		}
	}

	public void CheckGrounded(){
		/*
		if (xDirection != 0 && yDirection != 0) {
			currentDetectorCollider.enabled = false;
		}
		*/

		if (xDirection == 0 && yDirection == 1) {
			currentDetectorCollider = allDirectionalColliders [0];
		}
		if (xDirection == 0 && yDirection == -1) {
			currentDetectorCollider = allDirectionalColliders [1];
		}
		if (xDirection == -1 && yDirection == 0) {
			currentDetectorCollider = allDirectionalColliders [2];
		}
		if (xDirection == 1 && yDirection == 0) {
			currentDetectorCollider = allDirectionalColliders [3];
		}
		currentDetectorCollider.enabled = true;
	}

	public void SetGrounded(){
		isGrounded = true;
		xDirection = 0;
		yDirection = 0;
		currentDetectorCollider.enabled = false;
	}

	public void PlaySoundAttack(){//15-09-2018
		int tmp = Random.Range (0, playerSoundEffects.allClipsToPlay.Count);
		print (tmp);
		playerSoundEffects.PlayClip (tmp);
	}//15-09-2018
}
