using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour {
	public string SceneName;
	void Start()
	{
		GetComponent<Button>().onClick.AddListener(ChangeScene);
	}

	void ChangeScene() {
		SceneManager.LoadScene(SceneName);
	}
}