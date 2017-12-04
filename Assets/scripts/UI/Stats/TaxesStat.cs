using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TaxesStat : MonoBehaviour {
	Text Text;
	void Start() {
		Text = GetComponent<Text>();
	}
	void Update() {
		Text.text = "Налоги: " + TaxesController.Global.Taxe;
	}
}