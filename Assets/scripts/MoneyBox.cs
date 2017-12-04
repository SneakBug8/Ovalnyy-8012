using UnityEngine;

public class MoneyBox : MonoBehaviour {
	public int Count;
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == Player.Global.gameObject) {
			Player.Global.State.Money += Count;
			Destroy(gameObject);
		}
	}
}