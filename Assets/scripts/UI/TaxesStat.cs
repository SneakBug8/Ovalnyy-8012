using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TaxesStat : MonoBehaviour {
	public Text Text;
	public void Start() {
		Text = GetComponent<Text>();
	}
	public void Update() {
		Text.text = "Налоги: " + TaxesController.Global.Taxe;
	}
}