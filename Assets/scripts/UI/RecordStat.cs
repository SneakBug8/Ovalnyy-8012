using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RecordStat : MonoBehaviour {
	private Text Text;
	public void Start() {
		Text = GetComponent<Text>();
	}
	public void Update() {
		Text.text = "Ваш рекорд: " + RecordController.Global.Record;
	}
}