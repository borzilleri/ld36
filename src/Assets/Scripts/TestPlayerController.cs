using UnityEngine;
using System;
using System.Collections;

public class TestPlayerController : MonoBehaviour
{
	public float speed;

	private Rigidbody2D rb2d;
	private Animator animator;
	private bool facingRight;
	private string animationState;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		facingRight = false;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (Input.GetKeyDown ("space")) {
			setAnimation("Attack");
		}
		else if (moveHorizontal == 0 && moveVertical == 0) {
			setAnimation("Idle");
		} else {
			setAnimation("Walk");
			if (moveHorizontal > 0 != facingRight) {
				flip ();
			}
		}



//		animator.SetFloat ("speed", Mathf.Abs(moveHorizontal));
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical) * speed;
		rb2d.AddForce (movement);
	}

	private void flip() 
	{
		facingRight = !facingRight;
		Vector3 currentScale = transform.localScale;
		currentScale.x *= -1;
		transform.localScale = currentScale;
	}

	private void setAnimation(string state) {
		if(animationState != state) {
			if (!String.IsNullOrEmpty(animationState)) {
				animator.ResetTrigger (animationState);
			}
			animator.SetTrigger (state);
			animationState = state;
		}
	}
}
