using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpControl : MonoBehaviour {

	public GameObject[] allObjects;
	public bool thisIsMainScene;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AppearObjects(){
		for (int i = 0; i < allObjects.Length; i++) {
			allObjects [i].SetActive (true);
		}
		if (thisIsMainScene == true) {
			allObjects [allObjects.Length - 1].SetActive (false);
		}
	}
	public void DisappearObjects(){
		for (int i = 0; i < allObjects.Length; i++) {
			allObjects [i].SetActive (false);
		}
	}
}
