using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour {
	public static Player Global;
	public int Money = 0;
	public int Subscribers = 0;
	public Skill[] Skills;

	public float Speed;
	void Start() {
		Global = this;
	}

	// Update is called once per frame
	void Update() {
		var movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		transform.Translate(movement * Time.deltaTime * Speed);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "mob") {
			var mob = other.gameObject.GetComponent<Mob>();
			if (Subscribers > mob.Cost) {
				Subscribers -= mob.Cost;
				Destroy(mob.gameObject);
			} else {
				Money -= mob.Cost;
				mob.Stop(5);
			}
		}
	}

	IEnumerator Subscribe() {
		while (true) {
			// TODO: Change to formula
			Subscribers += 1000;
			yield return new WaitForSeconds(1f);
		}
	}
}