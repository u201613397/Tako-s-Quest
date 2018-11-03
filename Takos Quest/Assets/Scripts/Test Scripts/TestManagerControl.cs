using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestManagerControl : MonoBehaviour {

	public Text consoleTextResult;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetConsoleResultText(string t){
		consoleTextResult.text = t;
	}
}
