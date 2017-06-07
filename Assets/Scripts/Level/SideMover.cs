using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMover : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Vector2 vel = rb.velocity;
		vel.x = -speed;
		rb.velocity = vel;
	}
}
