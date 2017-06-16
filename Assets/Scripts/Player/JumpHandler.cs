using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour {

	public PlayerManager pm;

	public GameObject topPlayer;
	public GameObject bottomPlayer;


	//jump stuff
	public Transform groundCheckTop;
	public Transform groundCheckBottom;
	public LayerMask theGround;
	public float groundCheckRadius;

	public float jumpForce;
	public bool onGround;
	//////////////


	private Rigidbody2D rbTop;
	private Rigidbody2D rbBottom;


	void Start () {
		rbTop = topPlayer.GetComponent<Rigidbody2D>();
		rbBottom = bottomPlayer.GetComponent<Rigidbody2D>();

		onGround = true;
	}

	void FixedUpdate() {
		onGround = Physics2D.OverlapCircle(groundCheckTop.position, groundCheckRadius, theGround)
			|| Physics2D.OverlapCircle(groundCheckBottom.position, groundCheckRadius, theGround);
	}

	//to add menu button to play screen, need to change this
	void Update () {
		if(Input.touchCount > 0) {
			if (onGround) {
				foreach (Touch touch in Input.touches) {
					if (touch.position.x < Screen.width / 2) {
						Jump();
						break;
					}
				}
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			if (onGround) {
				if (Input.mousePosition.x < Screen.width / 2) {
					Jump();
					//Debug.Log("Pressed LEFT side");
				}
			}
		}
	}



	public void Jump() {
		if (pm.topActive) {
			rbTop.AddForce(transform.up * jumpForce);
			onGround = false;
		}
		else {
			rbBottom.AddForce(transform.up * -jumpForce);
			onGround = false;
		}
	}
}
