using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemyMeleeContainerControl : MonoBehaviour {

	[Header("Enemy Melee Variables")]
	public GameObject enemyToCreate;
	public List<EnemyMeleeControl> allEnemyMeleeList;

	[Header("Manager Variables")]
	public GameManagerControl gmManager;//04-11-2018 INCREMENTAR NÚMERO DE ENEMIGOS DERROTADOS
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateEnemyMelee(int x, int y, float xDistance, float yDistance){
		Vector3 tmpPosition = new Vector3 (x * xDistance, -y * yDistance, 0);
		GameObject tmp = Instantiate (enemyToCreate, tmpPosition, transform.rotation);
		tmp.transform.SetParent (this.transform);
		allEnemyMeleeList.Add (tmp.GetComponent<EnemyMeleeControl> ());
		tmp.GetComponent<EnemyMeleeControl> ().enemyContainer = this.gameObject.GetComponent<AllEnemyMeleeContainerControl>();//04-11-2018 INCREMENTAR NÚMERO DE ENEMIGOS
	}
	public void SendIncreaseEnemiesDefeated(){//04-11-2018 INCREMENTAR NÚMERO DE ENEMIGOS DERROTADOS
		gmManager.IncreaseEnemiesDefeated ();
	}//04-11-2018 INCREMENTAR NÚMERO DE ENEMIGOS DERROTADOS
}
