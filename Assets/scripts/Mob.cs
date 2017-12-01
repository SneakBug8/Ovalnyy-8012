using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour {

	NavMeshAgent agent;

	public int Cost;

	// Use this for initialization
	void Start() {
		agent.destination = Player.Global.transform.position;
	}

	public void Stop(int time) {
		StartCoroutine(Stopping(time));
	}

	IEnumerator Stopping(int time) {
		var a = agent.speed;
		agent.speed = 0;
		yield return new WaitForSeconds(time);
		agent.speed = a;
	}
}