using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllChangeDirectionBlockContainer : MonoBehaviour {

	[Header("Change Direction Block Variables")]
	public GameObject changeDirectionBlockToCreate;
	public List<ChangeDirectionBlockControl> allChangeDirectionBlockList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CreateChangeDirectionBlock(int x, int y, float xDistance, float yDistance){
		Vector3 tmpPosition = new Vector3 (x * xDistance, -y * yDistance, 0);
		GameObject tmp = Instantiate (changeDirectionBlockToCreate, tmpPosition, transform.rotation);
		tmp.transform.SetParent (this.transform);
		allChangeDirectionBlockList.Add (tmp.GetComponent<ChangeDirectionBlockControl> ());
		tmp.GetComponent<ChangeDirectionBlockControl> ().changeDirectionBlockContainer = this.gameObject.GetComponent<AllChangeDirectionBlockContainer>();
		tmp.GetComponent<MapPartControl> ().SetInitialValues (0, 0, 9);
	}
}
