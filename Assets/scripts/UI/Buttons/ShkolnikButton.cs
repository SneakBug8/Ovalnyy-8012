using UnityEngine;
using UnityEngine.UI;

public class ShkolnikButton : MonoBehaviour {
	Button button;

	void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(onClick);
	}

	void onClick() {
		Player.Global.GetComponent<ShkolnikSkill>().Activate();
	}
}