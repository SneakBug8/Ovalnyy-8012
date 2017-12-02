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
	public void Update() {
		var movement = new Vector2();
		if (Up.IsPressed) {
			movement.y = 1;
		}
		if (Down.IsPressed) {
			movement.y = -1;
		}
		if (Left.IsPressed) {
			movement.x = -1;
		}
		if (Right.IsPressed) {
			movement.x = 1;
		}

		Player.Global.transform.Translate(movement * Time.deltaTime * Player.Global.Speed);
	}
}