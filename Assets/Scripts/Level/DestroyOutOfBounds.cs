using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {

	//should destroy on left, not right
	void OnBecameInvisible() {
		if(transform.position.x < 0)
			Destroy(gameObject);
	}

}
