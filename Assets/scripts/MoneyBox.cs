using UnityEngine;

public class MoneyBox : MonoBehaviour {
	public int Count;

	public void Activate() {
		Player.Global.Money += Count;
		Destroy(gameObject);
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject == Player.Global) {
			Activate();
		}
	}
}