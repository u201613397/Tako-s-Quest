using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour {

	public TestManagerControl testManager; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Test") {
			testManager.SetConsoleResultText ("COLLISION ENTER");
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Test") {
			testManager.SetConsoleResultText ("COLLISION EXIT");
		}
	}
}
