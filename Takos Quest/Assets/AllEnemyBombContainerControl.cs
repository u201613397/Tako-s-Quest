using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemyBombContainerControl : MonoBehaviour {

	private int direction = 1;

	[Header("Enemy Bomb Variables")]
	public GameObject enemyToCreate;
	public List<EnemyBombControl> allEnemyBombList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CreateEnemyBomb(int x, int y, float xDistance, float yDistance, int typeOfMovement){
		Vector3 tmpPosition = new Vector3 (x * xDistance, -y * yDistance, 0);
		GameObject tmp = Instantiate (enemyToCreate, tmpPosition, transform.rotation);
		tmp.transform.SetParent (this.transform);
		tmp.GetComponent<EnemyBombControl> ().SetInitialVariables (typeOfMovement,direction);
		direction = direction * -1;
		allEnemyBombList.Add (tmp.GetComponent<EnemyBombControl> ());
		tmp.GetComponent<EnemyBombControl> ().enemyBombContainer = this.gameObject.GetComponent<AllEnemyBombContainerControl>();
	}
}
