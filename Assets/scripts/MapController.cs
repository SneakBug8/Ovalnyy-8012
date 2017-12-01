using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {
	public static MapController Global;
	public Vector2 MapBounds;
	private void Start() {
		Global = this;
	}
}