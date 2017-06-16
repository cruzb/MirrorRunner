using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour {

	public GameManager gm;

	//should destroy on left, not right
	void OnBecameInvisible() {
		if (gm != null) {
			gm.Remove();
		}
		else { GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Remove(); }
		if (transform.parent.position.x < 0)
			Destroy(transform.parent.gameObject);
	}
}
