using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapControl : MonoBehaviour {

	public List<int> allTags;
	public bool canDetectTag;

	[Header("Death Trap Container Variables")]
	public AllDeathTrapContainer deathTrapContainer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (CheckForTag (other.gameObject.layer) == true && canDetectTag == true) {
			other.GetComponent<PlayerControl> ().Dead ();
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
}
