using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;
using System;

public class Player : MonoBehaviour {
	public static Player Global;

	[Serializable]
	public class PlayerConfigurationData {
		public float Speed;		
	}
	[Serializable]
	public class PlayerStateData {
		public int Money = 0;
		public int Subscribers = 0;		
	}

	public PlayerConfigurationData Config;
	private PlayerStateData State;

	public int Subscribers {
		get {
			return State.Subscribers;
		}
		set {
			State.Subscribers = value;
		}
	}

	public int Money {
		get {
			return State.Money;
		}
		set {
			State.Money = value;
		}
	}
	
	public Skill[] Skills;

	Animator animator;
	void Awake() {
		Global = this;
	}
	void Start()
	{
		animator = GetComponent<Animator>();
		StartCoroutine(Subscribe());
		animator.SetBool("IsDead", false);
	}

	void Update()
	{
		if (State.Money < 0) {
			SceneManager.LoadScene("lost");
		}
		if (State.Money > RecordController.Global.Record) {
			RecordController.Global.Record = State.Money;
		}
	}

	public void Move(Vector2 direction) {
		var movement = direction * Time.deltaTime * Config.Speed;

		if (movement != Vector2.zero) {
			animator.SetBool("IsMoving", true);
		} else {
			animator.SetBool("IsMoving", false);			
		}
		transform.Translate(movement);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "mob") {
			var mob = other.gameObject.GetComponent<Mob>();
			if (State.Subscribers > mob.Cost) {
				Debug.Log("Collision for subscribers");
				State.Subscribers -= mob.Cost;
				mob.Die();
			} else {
				Debug.Log("Collision for money");				
				State.Money -= mob.Cost;
				mob.Stop(5);
			}
		}
	}

	IEnumerator Subscribe() {
		while (true) {
			float med = 0;
			foreach (var spawner in MobManager.Global.Spawners) {
				var mob = spawner.Mob;
				if (mob.activeSelf) {
					med += Vector3.Distance(transform.position, mob.transform.position);
				}
			}
			med = med / MobManager.Global.Spawners.Length;
			var diff = 100 - (int) med;
			if (diff < 0) {
				diff = 0;
			}
			State.Subscribers += diff;
			
			yield return new WaitForSeconds(1f);
		}
	}
}