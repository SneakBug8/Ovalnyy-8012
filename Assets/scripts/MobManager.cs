using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobManager : MonoBehaviour {
	public static MobManager Global;
	public float TimeToRespawn;
	public List<GameObject> Mobs = new List<GameObject>();

	public Sprite[] Sprites;

	private void Awake() {
		Global = this;
	}

	void Start() {
		foreach (var mob in Mobs) {
			mob.SetActive(true);
		}
	}

	public void Respawn(GameObject mob) {
		StartCoroutine(RespawnCoroutine(mob));
	}

	IEnumerator RespawnCoroutine(GameObject mob) {
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