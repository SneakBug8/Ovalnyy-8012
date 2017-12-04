using UnityEngine;
using UnityEngine.UI;

public class NavControl : Button {
	[HideInInspector]
	public bool IsPressed = false;
	void Update()
  {
    if(IsPressed())
    {
		IsPressed = true;
    } else {
		IsPressed = false;
	}
  }
 
}