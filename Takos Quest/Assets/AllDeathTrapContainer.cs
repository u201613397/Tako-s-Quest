using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDeathTrapContainer : MonoBehaviour {

	[Header("Death Trap Variables")]
	public GameObject trapToCreate;
	public List<DeathTrapControl> allDeathTrapList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CreateDeathTrap(int x, int y, float xDistance, float yDistance){
		Vector3 tmpPosition = new Vector3 (x * xDistance, -y * yDistance, 0);
		GameObject tmp = Instantiate (trapToCreate, tmpPosition, transform.rotation);
		tmp.transform.SetParent (this.transform);
		allDeathTrapList.Add (tmp.GetComponent<DeathTrapControl> ());
		tmp.GetComponent<DeathTrapControl> ().deathTrapContainer = this.gameObject.GetComponent<AllDeathTrapContainer>();
	}
}
