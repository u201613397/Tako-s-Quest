using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsContainerControl : MonoBehaviour {

	public List<StarControl> allStarsContainer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CheckForStars(int level){
		string tmp = "Level" + level.ToString () + "StarsEarned";
		int stars = PlayerPrefs.GetInt (tmp);
		//print ("En el nivel: " + level.ToString () + " hay " + stars.ToString ());
		for (int i = 0; i < stars; i++) {
			allStarsContainer [i].SetSprite (1);
		}
	}
}
