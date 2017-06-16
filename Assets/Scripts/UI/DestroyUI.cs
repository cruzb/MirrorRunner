using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUI : MonoBehaviour {

	void OnBecameInvisible () {
		Destroy(transform.parent.transform.parent);
	}
}
