using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragControl : MonoBehaviour {

	public float dist;
	private Vector3 v3OrgMouse;
	private Plane plane = new Plane(Vector3.up, Vector3.zero);

	public bool canMoveCamera;

	public float smoothTimeX;
	public float smoothTimeY;
	private Vector2 velocity;

	public bool timeToSeeObject;
	public GameObject objectToSee;

	public float minPositionX;
	public float maxPositionX;

	public float minPositionY;
	public float maxPositionY;

	void Start() {
		dist = transform.position.z;
	}

	void Update() {
		if (canMoveCamera == true) {
			if (Input.touchCount == 1) {
				Touch touchZero = Input.GetTouch (0);
				if (touchZero.phase == TouchPhase.Began) {
					Ray ray = Camera.main.ScreenPointToRay (touchZero.position);
					float dist;
					plane.Raycast (ray, out dist);
					v3OrgMouse = ray.GetPoint (dist);
					v3OrgMouse.z = 0;
				} else if (touchZero.phase == TouchPhase.Moved) {
					Ray ray = Camera.main.ScreenPointToRay (touchZero.position);
					float dist;
					plane.Raycast (ray, out dist);
					Vector3 v3Pos = ray.GetPoint (dist);
					v3Pos.z = 0;
					transform.position -= (v3Pos - v3OrgMouse);
					transform.position = new Vector3 (
						Mathf.Clamp (transform.position.x, minPositionX, maxPositionX),
						Mathf.Clamp (transform.position.y, minPositionY, maxPositionY),
						transform.position.z
					);
				}
			}
		}
	}
}