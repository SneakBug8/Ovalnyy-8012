using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MobManager : MonoBehaviour {
	public static MobManager Global;
	public MobSpawner[] Spawners;

	[Serializable]
	public class MobSpawner {
		public GameObject Mob;
		public float TimeToRespawn;
		
	}
	private void Awake() {
		Global = this;
	}

	void Start() {
		foreach (var spawn in Spawners) {
			spawn.Mob.SetActive(true);
		}
	}

	public void Respawn(Mob mob) {
		MobSpawner spawner = null;
		foreach (var spawn in Spawners) {
			if (spawn.Mob == mob) {
				spawner = spawn;
				break;
			}
		}

		if (spawner != null) {
			StartCoroutine(RespawnCoroutine(spawner));
		}
		else {
			Debug.LogError("No such mob to respawn");
		}
	}

	IEnumerator RespawnCoroutine(MobSpawner spawner) {
		var mob = spawner.Mob;
		var TimeToRespawn = spawner.TimeToRespawn;
		
		//TODO: Check min distance to Player
		var comp = mob.GetComponent<Mob>();
		comp.Cost += comp.AdditionAfterDeath;
		yield return new WaitForSeconds(TimeToRespawn);
		mob.transform.position = MapController.Global.RandomPosition();
		yield return new WaitForEndOfFrame();
		mob.SetActive(true);
		mob.GetComponent<BoxCollider2D>().enabled = true;		
	}
}