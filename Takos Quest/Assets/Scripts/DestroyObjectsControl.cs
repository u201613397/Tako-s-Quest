using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsControl : MonoBehaviour {

	public string objectToDestroyTag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == objectToDestroyTag) {
			if (other.GetComponent<EnemyMeleeControl> () != null) {//04-11-2018 INCREMENTAR NÚMERO DE ENEMIGOS
				other.GetComponent<EnemyMeleeControl> ().Die ();
			}//04-11-2018 INCREMENTAR NÚMERO DE ENEMIGOS
			//Destroy (other.gameObject);
		}
	}
}
