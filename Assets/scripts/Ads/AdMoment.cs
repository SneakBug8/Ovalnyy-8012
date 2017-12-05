using UnityEngine;

public class AdMoment : MonoBehaviour {
	public string MomentName;

	private void Start() {
		#if UNITY_ANDROID
		Kiip.saveMoment(MomentName);
		Kiip.showPoptart();
		#endif
	}
}