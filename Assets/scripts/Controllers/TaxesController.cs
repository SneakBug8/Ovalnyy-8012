using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxesController : MonoBehaviour {
	public static TaxesController Global;
	public int Taxe;
	private void Start() {
		Global = this;
		StartCoroutine(UpTaxes());
	}

	IEnumerator UpTaxes() {
		Taxe += 1;
		yield return new WaitForSeconds(10);
		StartCoroutine(UpTaxes());
	}
}