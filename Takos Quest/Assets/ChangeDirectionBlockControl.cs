using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirectionBlockControl : MonoBehaviour {

	[Header("Change Direction Block Container Variables")]
	public AllChangeDirectionBlockContainer changeDirectionBlockContainer;
	[Header("Player Direction Variables")]
	public int xDirection = 0;
	public int yDirection = -1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			other.GetComponent<PlayerControl> ().SimulateChangedDirection (xDirection, yDirection);
			print ("Envia el cambio");
		}
	}
	*/
}
