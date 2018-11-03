using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMusicControl : MonoBehaviour {
	private static ConstantMusicControl instance = null;
	public static ConstantMusicControl Instance {
		get { return instance; }
	}
	void Awake () {
		
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}


