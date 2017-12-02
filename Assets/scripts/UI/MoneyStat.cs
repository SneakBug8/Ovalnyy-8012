using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MoneyStat : MonoBehaviour {
	private Text Text;
	public void Start() {
		Text = GetComponent<Text>();
	}
	public void Update() {
		Text.text = "Деньги: " + Player.Global.Money;
	}
}