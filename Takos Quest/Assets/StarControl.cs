using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarControl : MonoBehaviour {

	private Image starImage;
	public Sprite[] allStarsSprites;
	// Use this for initialization
	void Awake () {
		starImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetSprite(int val){
		starImage.sprite = allStarsSprites [val];
	}
}
