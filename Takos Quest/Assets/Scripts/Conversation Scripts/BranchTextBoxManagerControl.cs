using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchTextBoxManagerControl : MonoBehaviour {

	[Header("Dialogue Lines Variables")]
	public TextAsset txtArchive;
	public string[] dialogueLines;
	public int currentLine;
	public int endAtLine;
	public Text dialogueText;

	[Header("Player Name Variables")]
	public bool isAPlayerName;
	public string realLineWithPlayerName;
	public string playerNameString;

	[Header("Text Box Variables")]
	public GameObject textBox;
	public bool isActiveTextBox;

	[Header("Recapitulation Text Box Variables")]
	public Text recapitulationText;
	public GameObject controlRecapButton;

	[Header("Typing Variables")]
	private bool isTyping = false;
	private bool cancelTyping = false;
	public float typeSpeed;

	[Header("Character Variables")]
	public int currentCharacter;
	public int portraitAnimationToSend;
	public int portraitEmotionToSend;
	public int portraitPoseToSend;
	public ConversationPortraitContainer allCharactersPortraits;
	private int previousEmotionTmp = -1;
	private int previousReceptorTmp = -1;

	[Header("Text Lines Activators Variables")]
	public BranchActivateTextAtLineControl[] arrayOfActivateTexts;
	public int currentActivateText;
	public int timeForNextDialogue;
	public int nextDialogue;
	public int[] positionsToSendAfterAnswer;

	[Header("Answer Variables")]
	public bool haveResponse;
	public BranchAnswersContainer answersContainer;
	public string[] answersTexts;

	[Header("Load Scenes Variables")]
	public LoadingControl loadLevel;
	public LoadingControl loadMap;
	public int currentMomentConversation;

	[Header("Sound Variables")]
	public ConversationSoundsControl conversationSounds;
	public ConstantMusicControl cons;
	// Use this for initialization
	void Start () {
	//	cons = (ConstantMusicControl)GameObject.Find ("BGMusic").GetComponent<ConstantMusicControl> ();

		if (txtArchive != null) {
			dialogueLines = txtArchive.text.Split ('\n');
		}
		if (endAtLine == 0) {
			endAtLine = dialogueLines.Length - 1;
		}
		if (isActiveTextBox == true) {
			EnabledTextBox ();
		} else if (isActiveTextBox == false) {
			textBox.SetActive (false);
			isActiveTextBox = false;
		}
		currentMomentConversation = PlayerPrefs.GetInt ("ConversationMoment");
	}

	// Update is called once per frame
	void Update () {
		if (isActiveTextBox == false) {
			return;
		}
		if (Input.GetButtonDown ("Fire1")) {
			if (isTyping == false) {
				currentLine += 1;
				if (currentLine > endAtLine) {
					if (haveResponse == true) {
						answersContainer.gameObject.SetActive(true);
						answersContainer.SetAllOptionsTexts(answersTexts);
						answersContainer.ShuffleResponses ();
						DisabledTextBox ();
						recapitulationText.text = dialogueLines[endAtLine];
						controlRecapButton.gameObject.SetActive(true);
					} else {
						Invoke ("EnableNextDialogueText", timeForNextDialogue);
						DisabledTextBox ();
					}
				} else {
					StartCoroutine (TextScroll (dialogueLines [currentLine]));
				}
			} else if (isTyping == true && cancelTyping == false) {
				cancelTyping = true;
			}
		}
	}
	private IEnumerator TextScroll(string lineOfDialogue){
		int currentLetter = 0;
		dialogueText.text = "";
		isTyping = true;
		cancelTyping = false;
		if (isAPlayerName == true) {
			CalculateRealStringLine (lineOfDialogue);
			lineOfDialogue = realLineWithPlayerName;
		}
		while (isTyping == true && cancelTyping == false && (currentLetter < lineOfDialogue.Length - 1)) {
			dialogueText.text += lineOfDialogue [currentLetter];
			currentLetter += 1;
			yield return new WaitForSeconds(typeSpeed);
		}
		dialogueText.text = lineOfDialogue;
		isTyping = false;
		cancelTyping = false;
	}

	public void EnabledTextBox(){
		textBox.SetActive (true);
		isActiveTextBox = true;
		textBox.GetComponent<DialogueBoxContainerControl> ().SelectEmisor (currentCharacter);

		if (currentCharacter != previousReceptorTmp) {
			allCharactersPortraits.ChangePortrait (currentCharacter, portraitPoseToSend, portraitEmotionToSend);
			previousReceptorTmp = currentCharacter;
			previousEmotionTmp = portraitEmotionToSend;
			conversationSounds.PlayClip(portraitEmotionToSend);
		} else {
			if (portraitEmotionToSend != previousEmotionTmp) {
				allCharactersPortraits.ChangePortrait (currentCharacter, portraitPoseToSend, portraitEmotionToSend);
				previousEmotionTmp = portraitEmotionToSend;
				conversationSounds.PlayClip(portraitEmotionToSend);
			}
		}

		StartCoroutine (TextScroll (dialogueLines [currentLine]));
	}

	public void DisabledTextBox(){
		textBox.SetActive (false);
		isActiveTextBox = false;

	}
	public void ReloadScript(TextAsset actualText, int portraitEmotionToAppear, int portraitCharacterToAppear, int portraitPose){
			dialogueLines = new string[1];
			dialogueLines = actualText.text.Split ('\n');

			portraitPoseToSend = portraitPose;
			portraitEmotionToSend = portraitEmotionToAppear;
			currentCharacter = portraitCharacterToAppear;

	}
	public void EnableNextDialogueText(){
		if (arrayOfActivateTexts [currentActivateText].isFinalDialogue == false) {
			currentActivateText = nextDialogue;
			arrayOfActivateTexts [currentActivateText].SendReloadTextBoxManager ();
		} else if (arrayOfActivateTexts [currentActivateText].isFinalDialogue == true){
			if (currentMomentConversation == 0) {
				loadLevel.ActivateLoadingCanvas ();
				//Destroy(cons.gameObject);
			} else {
				loadMap.ActivateLoadingCanvas ();
			}
		}
	}
	public void EnableNextDialogueTextAfterAnswer(){
		currentActivateText = nextDialogue;
		arrayOfActivateTexts [currentActivateText].SendReloadTextBoxManager ();
	}

	public void SetAnswerText(int initialLineText){
		for (int i = 0; i < 3; i++) {
			answersTexts [i] = dialogueLines [i + initialLineText];
		}
	}

	public void SetNextDialogue(int nextDialogueSend){
		nextDialogue = positionsToSendAfterAnswer [nextDialogueSend];
	}
	public void SetNextLinealDialogue(int nextDialogueSend){
		nextDialogue = nextDialogueSend;
	}
	public void SetPositions(int[] positions){
		positionsToSendAfterAnswer = positions;
	}

	public void CalculateRealStringLine(string lineOfDialogue){
		realLineWithPlayerName = "";
		for (int i = 0; i < lineOfDialogue.Length; i++) {
			if (lineOfDialogue [i] != '#') {
				realLineWithPlayerName = realLineWithPlayerName + lineOfDialogue [i];
			} else if (lineOfDialogue [i] == '#') {
				realLineWithPlayerName = realLineWithPlayerName + playerNameString;
			}
		}
	}
}
