using UnityEngine;
using System.Collections;

public class SpikeEnemyContoller : MonoBehaviour {

	public Transform target;
	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v = target.position;
		v.y += 0.6f;
		if (Vector2.Distance (transform.position, v) > 0.02f) {
			transform.position = Vector2.MoveTowards (transform.position, v, speed * Time.deltaTime);
		}
	}
}
