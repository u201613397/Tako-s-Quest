using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapContainerControl : MonoBehaviour {

	public float xDistance;
	public float yDistance;

	public int numbFilas;
	public int numbColumnas;

	public MapPartControl[,] bgMatrix;
	public int[,] bgMatrixValues;
	public string[] bgMatrixFilas;
	public string[] bgMatrixColumnas;
	public TextAsset bgMatrixtTxtArchive;
	public TextAsset[] allLevelsBgMatrixtTxtArchive;
	public GameObject objectToCreate;

	public GameManagerControl gameManager;//15-09-2018

	[Header("Map Part Sprites Variables")]
	public List<Sprite> allSprites;

	[Header("Player Variables")]
	public GameObject playerToCreate;

	[Header("Enemy Variables")]
	public GameObject enemyToCreate;//15-09-2018
	// Use this for initialization
	void Start () {
		StartFunctions (0);
	}
	
	public void StartFunctions(int currentLevel){
		bgMatrixtTxtArchive = allLevelsBgMatrixtTxtArchive [currentLevel];
		CreateMatrix ();
		CreateAllObjects ();
	}
	// Update is called once per frame
	void Update () {

	}
	public void CreateMatrix(){
		if (bgMatrixtTxtArchive != null) {
			bgMatrixFilas = bgMatrixtTxtArchive.text.Split ('\n');
		}

		bgMatrixColumnas = bgMatrixFilas [0].Split (',');

		numbFilas = bgMatrixFilas.Length;
		numbColumnas = bgMatrixColumnas.Length;
		bgMatrix = new MapPartControl[numbFilas, numbColumnas];
		bgMatrixValues = new int[numbColumnas, numbFilas];
		for (int i = 0; i < numbFilas; i++) {
			bgMatrixColumnas = bgMatrixFilas [i].Split (',');
			for (int j = 0; j < numbColumnas; j++) {
				bgMatrixValues [j, i] = int.Parse (bgMatrixColumnas [j]);
			}
		}
	}
	public void CreateAllObjects(){
		for (int i = 0; i < numbFilas; i++) {
			for (int j = 0; j < numbColumnas; j++) {
				if (bgMatrixValues [j, i] != 0) {
					Vector3 tmpPosition = new Vector3 (j * xDistance, -i * yDistance, 0);
					GameObject tmp = Instantiate (objectToCreate, tmpPosition, transform.rotation);
					tmp.transform.SetParent (this.transform);

					tmp.GetComponent<MapPartControl> ().SetInitialValues (j, i, bgMatrixValues [j, i]);
					tmp.GetComponent<MapPartControl> ().SetSprite (allSprites [bgMatrixValues [j, i]]);
					if (bgMatrixValues [j, i] != 1) {
						tmp.GetComponent<MapPartControl> ().ChangeCollider (true);
					}
					if (bgMatrixValues [j, i] == 1) {
						//tmp.GetComponent<MapPartControl> ().ChangeCollider (true);
						tmp.GetComponent<MapPartControl> ().ChangeCollider (false);
						tmp.layer = LayerMask.NameToLayer ("Ground");//04-09-2018 SETEAR LAYER SUELO

					}
					if (bgMatrixValues [j, i] == 3) {
						gameManager.CreatePlayer(j,i,xDistance,yDistance);//15-09-2018
						//Instantiate (playerToCreate, tmpPosition, transform.rotation);
					}

					if (bgMatrixValues [j, i] == 4) {//15-09-2018
						gameManager.SendCreateEnemyMelee(j,i,xDistance,yDistance);//15-09-2018
						//Instantiate (enemyToCreate, tmpPosition, transform.rotation);//15-09-2018
					}//15-09-2018
				}

			}
		}
	}
	void PrintMatrix(){
		for (int i = 0; i < numbFilas; i++) {
			for (int j = 0; j < numbColumnas; j++) {
				print ("Fila: " + i + " Columna: " + j + " valor: " + bgMatrixValues [j, i]);
			}
		}
	}
	public int GetValueInMatrixPosition(int x, int y){
		return bgMatrixValues [x, y];
	}
}
