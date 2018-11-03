using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour {

	public TestManagerControl testManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnSelection(){
		testManager.SetConsoleResultText ("IT WAS SELECTED");
	}
}
