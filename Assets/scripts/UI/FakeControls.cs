using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FakeControls : MonoBehaviour {
	public GameObject ControlPref;
	public void Start() {
		#if UNITY_ANDROID
			var obj = Instantiate(ControlPref);
			obj.transform.SetParent(gameObject.transform);
			obj.transform.localScale =new Vector3(1,1,1);
		#endif
	}
}