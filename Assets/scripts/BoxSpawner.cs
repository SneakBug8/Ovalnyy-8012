using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxSpawner : MonoBehaviour {
	public float TimeToRespawn;
	public int MaxGold;
	public GameObject BoxPref;
	void Start() {
		StartCoroutine(Respawn());
	}
	IEnumerator Respawn() {
		var GoldCount = Random.Range(0, MaxGold);
		var Box = Instantiate(BoxPref);
		Box.GetComponent<MoneyBox>().Count = GoldCount;
		yield return new WaitForSeconds(TimeToRespawn);
		StartCoroutine(Respawn());
	}

	Vector2 RandomPosition() {
		var MapBounds = MapController.Global.MapBounds;
		while (true) {
			var RandomPos = new Vector3(Random.Range(0, MapBounds.x), Random.Range(0, MapBounds.y), 10);
			RaycastHit ray;
			if (Physics.Raycast(RandomPos, Vector3.down, out ray, 100)) {
				if (ray.collider.gameObject.tag == "ground") {
					return new Vector2(RandomPos.x, RandomPos.y);
				}
			}
		}
	}
}