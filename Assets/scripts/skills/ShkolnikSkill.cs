using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShkolnikSkill : Skill {
	public ShkolnikSkill() {
		KeyCode = KeyCode.Alpha1;
	}
	public GameObject ShkolnikPref;
	protected GameObject obj;
	protected override void OnActivate() {
		obj = GameObject.Instantiate(ShkolnikPref);
		obj.transform.position = Player.Global.transform.position;
		Owner.MyStartCoroutine(AutoDestroy(obj));
	}

	IEnumerator AutoDestroy(GameObject obj) {
		yield return new WaitForSeconds(5);
		GameObject.Destroy(obj);
	}
}