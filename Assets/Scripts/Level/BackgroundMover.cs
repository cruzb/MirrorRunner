using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {
	/*
	public Vector2 startPosition;
	public float speed;

	void Update() {
		Vector2 position = transform.position;
		position.x -= Time.deltaTime * speed;
		transform.position = position;
	}

	void OnBecameInvisible() {
		transform.position = startPosition;	
	}*/
	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition;

	void Start() {
		startPosition = transform.position;
	}

	void Update() {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.left * newPosition;
	}
}
