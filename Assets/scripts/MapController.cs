using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
	public static MapController Global;

	public Vector2 DownLeft;
	public Vector2 UpperRight;
	private void Awake() {
		Global = this;
	}

	public bool IsWall(Vector3 position) {
		RaycastHit hit;
		var Upper = new Vector3(position.x, position.y, Camera.main.transform.position.z);
		if (Physics.Raycast(Upper, new Vector3(0,0,-1), out hit, 25)) {
				if (hit.collider.gameObject.tag == "wall") {
					return true;
				}
		}

		return false;
	}

	public Vector2 RandomPosition() {
		var RandomPos = new Vector3();
		while (true) {
			RandomPos = new Vector3(Random.Range(DownLeft.x, UpperRight.x), Random.Range(DownLeft.y, UpperRight.y), 10);
			if (!IsWall(RandomPos)) {
				break;
			}
		}

		return RandomPos;
	}
}
