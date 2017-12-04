using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour {
	public void MyStartCoroutine(IEnumerator coroutine) {
		StartCoroutine(coroutine);
	}
}