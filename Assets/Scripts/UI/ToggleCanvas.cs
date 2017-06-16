using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour {

	public Canvas c;

	public void Toggle() {
		if (c.gameObject.activeInHierarchy) 
			c.gameObject.SetActive(false);
		else c.gameObject.SetActive(true);
	}
}
