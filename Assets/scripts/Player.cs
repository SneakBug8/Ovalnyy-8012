using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class Player : MonoBehaviour {
	public static Player Global;

	public int Money = 0;
	public int Subscribers = 0;
	public Skill[] Skills;
	public float Speed;

	private Animator animator;
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
		if (Money < 0) {
			SceneManager.LoadScene("lost");
		}
		if (Money > RecordController.Global.Record) {
			RecordController.Global.Record = Money;
		}
	}

	public void Move(Vector2 direction) {
		var movement = direction * Time.deltaTime * Speed;

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
			if (Subscribers > mob.Cost) {
				Debug.Log("Collision for subscribers");
				Subscribers -= mob.Cost;
				mob.Die();
			} else {
				Debug.Log("Collision for money");				
				Money -= mob.Cost;
				mob.Stop(5);
			}
		}
	}

	IEnumerator Subscribe() {
		while (true) {
			float med = 0;
			foreach (var mob in MobManager.Global.Mobs) {
				med += Vector3.Distance(transform.position, mob.transform.position);
			}
			med = med / MobManager.Global.Mobs.Count;
			var diff = 100 - (int) med;
			if (diff < 0) {
				diff = 0;
			}
			Subscribers += diff;
			
			yield return new WaitForSeconds(1f);
		}
	}
}