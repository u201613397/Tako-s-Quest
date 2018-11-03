using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLevelButtonContainerControl : MonoBehaviour {

	public List<LevelButtonControl> allLevelButtons;
	// Use this for initialization
	void Start () {
		SetAllInitialButtonsFunctions ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetAllInitialButtonsFunctions(){
		for (int i = 0; i < allLevelButtons.Count; i++) {
			allLevelButtons [i].SetInitialValues (i+1);
			allLevelButtons [i].CalculateLevelState ();
		}
	}
}
