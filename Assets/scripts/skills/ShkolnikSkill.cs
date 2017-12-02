using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShkolnikSkill : Skill {
	public GameObject ShkolnikPref;
	protected GameObject obj;
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Activate();
		}
	}
	protected override void OnActivate() {
		obj = Instantiate(ShkolnikPref);
		obj.transform.position = Player.Global.transform.position;
		StartCoroutine(AutoDestroy(obj));
	}

	IEnumerator AutoDestroy(GameObject obj) {
		yield return new WaitForSeconds(5);
		Destroy(obj);
	}
}