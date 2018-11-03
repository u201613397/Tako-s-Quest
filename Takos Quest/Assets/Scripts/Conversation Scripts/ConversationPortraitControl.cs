using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationPortraitControl : MonoBehaviour {

	private Animator portraitAnim;
	public int numbOfVariations;
	[Header("Pose Sprites Variables")]
	public Sprite[] allSprites;
	public int currentSpriteValue;
	public SpriteRenderer currentSprite;
	[Header("Emotion Sprites Variables")]
	public Sprite[] allEmotionSprites;
	public int currentEmotionValue;
	public SpriteRenderer currentEmotion;
	[Header("Cloth Sprites Variables")]
	public Sprite[] allClothSprites;
	public int currentClothValue;
	public SpriteRenderer currentCloth;
	// Use this for initialization
	void Awake () {
		portraitAnim = GetComponent<Animator> ();
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AppearPortrait(int numbOfPos, int numbOfEmotion){
		this.gameObject.SetActive (true);
		currentSpriteValue = numbOfPos;
		currentEmotionValue = numbOfEmotion;
		currentClothValue = PlayerPrefs.GetInt ("ClothEquipped");

		currentSprite.sprite = allSprites [numbOfPos];
		currentEmotion.sprite = allEmotionSprites [currentEmotionValue];
		currentCloth.sprite = allClothSprites [currentClothValue * numbOfVariations + numbOfPos];
	}
	public void DisappearPortrait(){
		this.gameObject.SetActive (false);
	}
}
