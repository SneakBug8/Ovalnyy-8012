using UnityEngine;
using UnityEngine.UI;

public class ShkolnikButton : MonoBehaviour {
	Button button;

	private void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(onClick);
	}

	void onClick() {
		Player.Global.GetComponent<ShkolnikSkill>().Activate();
	}
}