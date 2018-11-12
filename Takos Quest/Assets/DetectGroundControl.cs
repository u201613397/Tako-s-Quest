using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGroundControl : MonoBehaviour {

	public List<int> allTags;
	public int typeOfDetector;
	public GameObject fatherObj;
	public bool canDetectTag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (CheckForTag (other.gameObject.layer) == true && canDetectTag == true) {
			switch (typeOfDetector) {
			case 0://ES UN ENEMIGO BOMBA
				fatherObj.GetComponent<EnemyBombControl> ().ChangeDirection (this.gameObject.GetComponent<DetectGroundControl>());
				canDetectTag = false;
				//print ("Entra");
				break;
			}
		}
	}
	bool CheckForTag(int tmp){
		for (int i = 0; i < allTags.Count; i++) {
			if (tmp == allTags [i]) {
				return true;
			}
		}
		return false;
	}
	public void ActivateDetector(float time){
		Invoke ("TrueActivateDetector", time);
	}
	void TrueActivateDetector(){
		canDetectTag = true;
	}
}
