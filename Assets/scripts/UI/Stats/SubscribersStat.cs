using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SubscribersStat : MonoBehaviour {
	Text Text;
	public void Start() {
		Text = GetComponent<Text>();
	}
	public void Update() {
		Text.text = "Подписчики: " + Player.Global.State.Subscribers;
	}
}