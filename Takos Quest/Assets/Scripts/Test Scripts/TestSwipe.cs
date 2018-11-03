using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwipe : MonoBehaviour {

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	public float swipeSensibility = 20f;
	public TestManagerControl testManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Swipe ();
	}

	public void Swipe(){
		if (Input.GetMouseButtonDown (0)) {
			firstPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			secondPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		}

		if (Input.GetMouseButtonUp (0)) {
			secondPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			CheckSwipe ();
		}
	}

	void CheckSwipe(){
		if (VerticalMove () > swipeSensibility && VerticalMove () > HorizontalValMove ()) {
			if (secondPressPos.y - firstPressPos.y > 0) {
				testManager.SetConsoleResultText ("UP SWIPE");
			} else if (secondPressPos.y - firstPressPos.y < 0) {
				testManager.SetConsoleResultText ("DOWN SWIPE");
			}
			firstPressPos = secondPressPos;
		} else if (HorizontalValMove () > swipeSensibility && HorizontalValMove () > VerticalMove ()) {
			if (secondPressPos.x - firstPressPos.x > 0) {
				testManager.SetConsoleResultText ("RIGHT SWIPE");
			} else if (secondPressPos.x - firstPressPos.x < 0) {
				testManager.SetConsoleResultText ("LEFT SWIPE");
			}
			firstPressPos = secondPressPos;
		} 
	}

	float VerticalMove(){
		return Mathf.Abs (secondPressPos.y - firstPressPos.y);
	}
	float HorizontalValMove(){
		return Mathf.Abs (secondPressPos.x - firstPressPos.x);
	}
}
