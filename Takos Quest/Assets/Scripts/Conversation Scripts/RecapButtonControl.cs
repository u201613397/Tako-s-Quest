using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecapButtonControl : MonoBehaviour {

	public GameObject recapBox;
	public Sprite[] spriteState;
	public int currentSprite;
	private Image buttonImage;
	// Use this for initialization
	void Start () {
		buttonImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeAppearTextBox(){
		int spriteTmp;
		spriteTmp = currentSprite;
		if (currentSprite == 0) {
			spriteTmp = 1;
			recapBox.gameObject.SetActive (true);
		}
		if (currentSprite == 1) {
			spriteTmp = 0;
			recapBox.gameObject.SetActive (false);
		}
		currentSprite = spriteTmp;
		buttonImage.sprite = spriteState [currentSprite];
	}
	void OnDisable(){
		currentSprite = 0;
		buttonImage.sprite = spriteState [currentSprite];
	}
}
