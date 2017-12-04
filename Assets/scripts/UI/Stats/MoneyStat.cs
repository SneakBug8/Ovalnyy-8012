using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MoneyStat : MonoBehaviour {
	Text Text;
	void Start() {
		Text = GetComponent<Text>();
	}
	void Update() {
		Text.text = "Деньги: " + Player.Global.State.Money;
	}
}