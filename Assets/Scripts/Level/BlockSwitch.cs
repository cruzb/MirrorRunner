using UnityEngine;
using System.Collections;

public class BlockSwitch : MonoBehaviour {

	public bool isActive;
	public Sprite block;
	public Sprite emptyBlock;


	private BoxCollider2D collider;
	private SpriteRenderer sr;
	
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D>();
		sr = GetComponent<SpriteRenderer>();

		if (isActive) {
			if (collider != null)
				collider.enabled = true;
			sr.sprite = block;
		} 
		else {
			if (collider != null)
				collider.enabled = false;
			sr.sprite = emptyBlock;
		}
	}

	void Update() {
		/*if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				if (touch.position.x > Screen.width / 2) {
					Switch();
					break;
				}
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			if (Input.mousePosition.x > Screen.width / 2) {
				Switch();
			}
		}*/
	}


	public void Switch(){
		//Debug.Log("Switch Called");
		
		if (isActive) {
			if(collider != null)
				collider.enabled = false;
			sr.sprite = emptyBlock;
		} 
		else {
			if (collider != null)
				collider.enabled = true;
			sr.sprite = block;
		}
		isActive = !isActive;

	}



}
