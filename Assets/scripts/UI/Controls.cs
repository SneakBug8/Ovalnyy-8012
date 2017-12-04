using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Controls : MonoBehaviour {
	public NavControl Up;
	public NavControl Down;
	public NavControl Left;
	public NavControl Right;
	void Update() {
		var direction = new Vector2();
		if (Up.IsPressed) {
			direction.y = 1;
		}
		if (Down.IsPressed) {
			direction.y = -1;
		}
		if (Left.IsPressed) {
			direction.x = -1;
		}
		if (Right.IsPressed) {
			direction.x = 1;
		}

		Player.Global.Move(direction);
	}
}