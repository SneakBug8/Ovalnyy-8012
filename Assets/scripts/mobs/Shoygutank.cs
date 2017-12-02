using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Shoygutank : Automob {
	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "shkolnik") {
			Destroy(other.gameObject);
		}
	}
}