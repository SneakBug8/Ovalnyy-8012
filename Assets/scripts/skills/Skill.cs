using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Skill : MonoBehaviour {
	public int Cost;
	public void Activate() {
		if (Player.Global.Subscribers >= Cost) {
			OnActivate();
			Player.Global.Subscribers -= Cost;
		}
	}

	protected virtual void OnActivate() { }
}