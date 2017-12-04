using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RecordStat : MonoBehaviour {
	private Text Text;
	void Start() {
		Text = GetComponent<Text>();
	}
	void Update() {
		Text.text = "Ваш рекорд: " + RecordController.Global.Record;
	}
}