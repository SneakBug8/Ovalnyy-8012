using UnityEngine;

public class ShowIfAndroid : MonoBehaviour {
	void Start()
	{
		#if UNITY_ANDROID
		gameObject.SetActive(true);
		#else
		gameObject.SetActive(false);		
		#endif
	}
}