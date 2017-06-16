using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMover : MonoBehaviour {

	public float speed;
	
	private RectTransform rt;

	void Start() {
		rt = gameObject.GetComponent<RectTransform>();
	}
	void Update() {
		Vector2 pos = rt.position;
		pos.x += -speed * Time.deltaTime;
		rt.position = pos;
	}
}
