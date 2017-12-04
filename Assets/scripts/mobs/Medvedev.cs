using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Medvedev : Mob {
	bool IsStopped = false;
	public float speed;
	private void Update() {
		if (!IsStopped) {
			var dest = PointToDirection(Player.Global.transform.position);
			transform.Translate(dest.normalized * speed * Time.deltaTime);
		}
	}

	public override void Stop(int time) {
		StartCoroutine(Stopping(time));
	}

	IEnumerator Stopping(int time) {
		IsStopped = true;
		var collider = gameObject.GetComponent<BoxCollider2D>();
		collider.enabled = false;
		yield return new WaitForSeconds(time);
		collider.enabled = true;
		IsStopped = false;
	}

	Vector2 PointToDirection(Vector2 destination) {
		Vector2 direction = transform.InverseTransformPoint(destination); //- transform.position;
		direction.Normalize();

		return direction;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject == Player.Global.gameObject) {
			Player.Global.State.Money = -1;
		}
	}
}