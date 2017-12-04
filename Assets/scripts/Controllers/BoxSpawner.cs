using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BoxSpawner : MonoBehaviour {
	public float TimeToRespawn;
	public int MaxGold;
	public GameObject BoxPref;
	void Start() {
		StartCoroutine(Respawn());
	}

	bool CheckTaxes() {
		var rand = Random.Range(0, 100);
		if (rand > TaxesController.Global.Taxe) {
			return true;
		}
		return false;
	}
	IEnumerator Respawn() {
		yield return new WaitForSeconds(3);
		while (true) {
			if (CheckTaxes()) {
				var GoldCount = Random.Range(0, MaxGold);
				var Box = Instantiate(BoxPref);
				BoxPref.transform.position = MapController.Global.RandomPosition();
				Box.GetComponent<MoneyBox>().Count = GoldCount;
				Box.GetComponentInChildren<TextMesh>().text = GoldCount.ToString();
			}

			yield return new WaitForSeconds(TimeToRespawn);			
		}
	}
}