using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public GameObject topPlayer;
	public GameObject bottomPlayer;

	private Rigidbody2D toprb;
	private Rigidbody2D bottomrb;

	public bool topActive;
	
	void Start () {
		toprb = topPlayer.GetComponent<Rigidbody2D>();
		bottomrb = bottomPlayer.GetComponent<Rigidbody2D>();
	}

	void Update () {
		//check if active should change
		if(Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				if (touch.position.x > Screen.width / 2) {
					topActive = !topActive;
					break;
				}
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			if(Input.mousePosition.x > Screen.width / 2) {
				topActive = !topActive;
				Debug.Log("Pressed RIGHT side");
			}
		}


		//mirror inactive
		if (topActive) {
			Vector2 pos = topPlayer.transform.position;
			pos.y = -pos.y;
			bottomPlayer.transform.position = pos;
			Vector2 vel = toprb.velocity;
			vel.y = -vel.y;
			vel.x = bottomrb.velocity.x;
			bottomrb.velocity = vel;
		}
		else {
			Vector2 pos = bottomPlayer.transform.position;
			pos.y = -pos.y;
			topPlayer.transform.position = pos;
			Vector2 vel = bottomrb.velocity;
			vel.y = -vel.y;
			vel.x = toprb.velocity.x;
			toprb.velocity = vel;
		}
	}
}
