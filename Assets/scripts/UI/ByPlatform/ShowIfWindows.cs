using UnityEngine;

public class ShowIfWindows : MonoBehaviour {
	void Start()
	{
		#if UNITY_WINDOWS
		gameObject.SetActive(true);
		#else
		gameObject.SetActive(false);		
		#endif
	}
}