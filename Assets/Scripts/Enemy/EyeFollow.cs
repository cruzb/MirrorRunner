using UnityEngine;
using System.Collections;

public class EyeFollow : MonoBehaviour {
	
	public Transform target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v = target.position;
		v.y += 0.6f;
		transform.LookAt (v);
		transform.Rotate(new Vector3(0, -90, 0), Space.Self); //offset fix
	}
}
