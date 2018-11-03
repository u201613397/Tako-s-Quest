using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpControl : MonoBehaviour {

	public GameObject[] allObjects;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AppearObjects(){
		for (int i = 0; i < allObjects.Length; i++) {
			allObjects [i].SetActive (true);
		}
	}
	public void DisappearObjects(){
		for (int i = 0; i < allObjects.Length; i++) {
			allObjects [i].SetActive (false);
		}
	}
}
