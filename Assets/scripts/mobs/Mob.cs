using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour {
	public int Cost;
	public bool SpriteRotation;
	public int TaxesReduce = 0;

	public int AdditionAfterDeath = 100;

	// Use this for initialization
	public virtual void Stop(int time) { }
	protected virtual void OnDie() {
		
	}

	public void Die() {
		OnDie();		
		// Sprite rotation
		TaxesController.Global.Taxe -= TaxesReduce;
		if (TaxesController.Global.Taxe < 0) {
			TaxesController.Global.Taxe = 0;			
		}
		MobManager.Global.Respawn(gameObject);
		gameObject.SetActive(false);
	}
}