using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeSoundValue : MonoBehaviour {

	private float soundsValue;
	public PlaySoundControl soundToAffect;
	public string typeSoundPref;
	private Slider _slide;
	public Text soundsValueText;
	// Use this for initialization
	void Awake () {
		_slide = GetComponent<Slider> ();
		soundsValue = PlayerPrefs.GetFloat (typeSoundPref);
		_slide.value = soundsValue*10;
		soundsValueText.text = (soundsValue*10).ToString ("F0");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeSoundsValue(){
		soundsValue = (_slide.value/10f);
		PlayerPrefs.SetFloat (typeSoundPref, soundsValue);
		soundsValueText.text = (soundsValue*10).ToString ("F0");
		soundToAffect.ApplicateChange ();
	}
	public void ChangeSoundWithButton(){
		if (soundsValue * 10 == 0) {
			soundsValue = 1;
			PlayerPrefs.SetFloat (typeSoundPref, soundsValue);
			soundsValueText.text = (soundsValue * 10).ToString ("F0");
			_slide.value = soundsValue*10;
			soundToAffect.ApplicateChange ();
		} else if (soundsValue * 10 != 0) {
			soundsValue = 0;
			PlayerPrefs.SetFloat (typeSoundPref, soundsValue);
			soundsValueText.text = (soundsValue * 10).ToString ("F0");
			_slide.value = soundsValue*10;
			soundToAffect.ApplicateChange ();
		}
	}

}
