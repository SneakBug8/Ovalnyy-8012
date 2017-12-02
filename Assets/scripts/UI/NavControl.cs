using UnityEngine;
using UnityEngine.UI;

public class NavControl : Button {
	public bool IsPressed = false;
	public void Update()
  {
    if(IsPressed())
    {
		IsPressed = true;
    } else {
		IsPressed = false;
	}
  }
 
}