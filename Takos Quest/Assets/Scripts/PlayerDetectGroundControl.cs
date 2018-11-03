using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectGroundControl : MonoBehaviour {

	public PlayerControl playerFather;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<MapPartControl> ().valueInMatrix == 1) {
			playerFather.SetGrounded ();
		}
	}
}
