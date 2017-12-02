using UnityEngine.UI;
using UnityEngine;

public class ViewButton : MonoBehaviour {
	Button button;

	public GameObject[] Enable;
	public GameObject[] Disable;

	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(changeView);
	}

	void changeView() {
		foreach (var obj in Enable) {
			obj.SetActive(true);
		}
		foreach (var obj in Disable) {
			obj.SetActive(false);
		}
	}
}