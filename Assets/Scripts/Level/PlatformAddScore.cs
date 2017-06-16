using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAddScore : MonoBehaviour {

	public ScoreManager sm;

	void Update () {
		if(transform.position.x < 0) {
			sm.PassPlatform();
			gameObject.GetComponent<PlatformAddScore>().enabled = false;
		}
	}
}
