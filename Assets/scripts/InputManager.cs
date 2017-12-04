using UnityEngine;

public class InputManager : MonoBehaviour {
	private void Update() {
		if (Player.Global != null) {
			Player.Global.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
		}
	}
}