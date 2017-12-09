using System;
using System.Collections;
using System.Collections.Generic;

using CnControls;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : Character {
	public static Player Global;

	[Serializable]
	public class PlayerConfigurationData {
		public float Speed;
		public Skill[] Skills;
	}
	[Serializable]
	public class PlayerStateData {
		public UnityEvent OnMoneyChange = new UnityEvent();
		int _money = 0;
		public int Money {
			get {
				return _money;
			}
			set {
				_money = value;
				OnMoneyChange.Invoke();
			}
		}
		public UnityEvent OnSubscribersChange = new UnityEvent();
		int _subscribers = 0;
		public int Subscribers {
			get {
				return _subscribers;
			}
			set {
				_subscribers = value;
				OnSubscribersChange.Invoke();
			}
		}
	}
	public PlayerConfigurationData Config;
	public PlayerStateData State = new PlayerStateData();
	Animator animator;
	void Awake() {
		Global = this;
	}
	void Start() {
		animator = GetComponent<Animator>();
		StartCoroutine(Subscribe());
		animator.SetBool("IsDead", false);

		foreach (var skill in Config.Skills) {
			skill.Owner = this;
		}

		State.OnMoneyChange.AddListener(OnMoneyListener);
	}

	void Update() {
		foreach (var skill in Config.Skills) {
			if (Input.GetKeyDown(skill.KeyCode)) {
				skill.Activate();
			}
		}

		#if UNITY_ANDROID
		Move(new Vector2(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis ("Vertical")));		
		#else
		Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
		#endif
	}

	void OnMoneyListener() {
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