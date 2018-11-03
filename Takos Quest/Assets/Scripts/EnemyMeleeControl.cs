using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeControl : MonoBehaviour {

	public float minXImpulse;
	public float maxXImpulse;
	public float minYImpulse;
	public float maxYImpulse;

	public int xDirection = 1;

	private Rigidbody2D rbEnemy;

	public bool affectByGravity;
	public float currentGravity = 0;
	public float speedAceleration = 0;
	// Use this for initialization
	void Start () {
		rbEnemy = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (affectByGravity == true) {
			currentGravity = currentGravity + speedAceleration * Time.deltaTime;
			rbEnemy.gravityScale = currentGravity;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerControl> ().PlaySoundAttack ();
			if (other.transform.position.x > transform.position.x) {
				xDirection = 1;
			} else {
				xDirection = -1;
			}
			FlyOff ();
			//Destroy (this.gameObject);
		}
	}

	public void FlyOff(){
		float randomXImpulse = Random.Range (minXImpulse, maxXImpulse);
		float randomYImpulse = Random.Range (minYImpulse, maxYImpulse);

		//enemyLeftAnimator.SetTrigger ("isDead");
		rbEnemy.velocity = new Vector2 (0, 0);
		rbEnemy.AddRelativeForce (new Vector2 (xDirection * randomXImpulse, randomYImpulse), ForceMode2D.Impulse);
		affectByGravity = true;
		//rbEnemy.gravityScale = 1F;
		//Invoke ("Die", 1f);
	}
	void Die(){
		Destroy(gameObject);
	}
}
