using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MapController : MonoBehaviour {
	public static MapController Global;

	public Vector2 DownLeft;
	public Vector2 UpperRight;
	private void Awake() {
		Global = this;
	}

	public bool IsWall(Vector2 position) {
		RaycastHit2D hit = Physics2D.Raycast(position, new Vector2(1, 0), 0.1f);
		if (hit.collider != null && hit.collider.gameObject.tag == "wall") {
			return true;
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