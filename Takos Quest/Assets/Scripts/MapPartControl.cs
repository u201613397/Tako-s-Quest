using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPartControl : MonoBehaviour {

	public int xPositionInMatrix;
	public int yPositionInMatrix;
	public int valueInMatrix;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetInitialValues(int x, int y, int val){
		xPositionInMatrix = x;
		yPositionInMatrix = y;
		valueInMatrix = val;
	}
	public void SetSprite(Sprite spr){
		GetComponent<SpriteRenderer> ().sprite = spr;
	}
	public void ChangeCollider(bool collid){
		GetComponent<BoxCollider2D> ().isTrigger = collid;
	}
}
