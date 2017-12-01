using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobManager : MonoBehaviour {
	public float TimeToRespawn;
	public Mob[] Mobs;
	IEnumerator Respawn(Mob mob) {
		var MapBounds = MapController.Global.MapBounds;
		mob.gameObject.SetActive(false);
		yield return new WaitForSeconds(TimeToRespawn);
		mob.transform.position = new Vector2(Random.Range(0, MapBounds.x), Random.Range(0, MapBounds.y));
		mob.gameObject.SetActive(true);
	}
}