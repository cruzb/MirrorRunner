using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

	public float amplitude;
	public float speed;

	private float startY;

	// Use this for initialization
	void Start() {
		startY = transform.position.y;

		if (transform.position.y < 0) {
			Vector2 scale = transform.localScale;
			scale.y = -scale.y;
			transform.localScale = scale;
		}
	}

	// Update is called once per frame
	void Update() {
		Vector2 v = new Vector2(transform.position.x, startY + amplitude * Mathf.Sin(speed * Time.time));
		transform.position = v;
	}
}
