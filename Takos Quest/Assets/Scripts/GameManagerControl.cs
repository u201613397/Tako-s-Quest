using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerControl : MonoBehaviour {

	public AllEnemyMeleeContainerControl allEnemyMeleeContainer;
	[Header("Player Variables")]
	public GameObject playerToCreate;
	public PlayerControl player;
	public PlaySoundControl playerSoundEffects;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SendCreateEnemyMelee(int x, int y, float xDistance, float yDistance){
		allEnemyMeleeContainer.CreateEnemyMelee (x, y, xDistance, yDistance);
	}

	public void CreatePlayer(int x, int y, float xDistance, float yDistance){
		Vector3 tmpPosition = new Vector3 (x * xDistance, -y * yDistance, 0);
		GameObject tmp = Instantiate (playerToCreate, tmpPosition, transform.rotation);
		player = tmp.GetComponent<PlayerControl> ();
		tmp.GetComponent<PlayerControl> ().playerSoundEffects = playerSoundEffects;
	}
}
