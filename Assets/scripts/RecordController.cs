using UnityEngine;

public class RecordController : MonoBehaviour {
	public static RecordController Global;
	public int Record {
		get {
			return PlayerPrefs.GetInt("Record");
		}
		set {
			PlayerPrefs.SetInt("Record", value);
		}
	}

	private void Awake() {
		Global = this;
	}
}