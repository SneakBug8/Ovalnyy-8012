using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Automob : Mob {
	private NavMeshAgent2D agent;
	private new BoxCollider2D collider;
	private Animator animator;
	void Start() {
		agent = GetComponent<NavMeshAgent2D>();
		collider = GetComponent<BoxCollider2D>();
		animator = GetComponent<Animator>();
		animator.SetBool("IsDead", false);
	}

	void OnEnable()
	{
		GetComponentInChildren<TextMesh>().text = Cost.ToString();		
	}

	private void Update() {
		agent.destination = Player.Global.transform.position;

		if (agent.speed > 0) {
			animator.SetBool("IsMoving", true);
		} else {
			animator.SetBool("IsMoving", false);			
		}
	}

	public override void Stop(int time) {
		StartCoroutine(Stopping(time));
	}

	IEnumerator Stopping(int time) {
		var a = agent.speed;
		agent.speed = 0;
		var collider = agent.GetComponent<BoxCollider2D>();
		collider.enabled = false;
		yield return new WaitForSeconds(time);
		collider.enabled = true;
		agent.speed = a;
	}

	protected override void OnDie() {
		animator.SetBool("IsDead", true);
		collider.enabled = false;
	}
}