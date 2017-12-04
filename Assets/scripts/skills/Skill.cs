using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Skill : MonoBehaviour {
	[HideInInspector]
	public Character Owner;
	public KeyCode KeyCode;
	public int Cost;
	public void Activate() {
		if (Player.Global.State.Subscribers >= Cost) {
			OnActivate();
			Player.Global.State.Subscribers -= Cost;
		}
	}

	protected virtual void OnActivate() { }
}