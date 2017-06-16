using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUtility : MonoBehaviour {

	public float timescale;

	void Start () {
		Time.timeScale = timescale;
	}

}
