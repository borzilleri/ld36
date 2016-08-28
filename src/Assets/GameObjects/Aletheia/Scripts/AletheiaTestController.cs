using UnityEngine;
using System.Collections;

public class AletheiaTestController : MonoBehaviour {
	public float speed;
	public Animator animator;

	private bool facingRight;
	private string animationState;

	// Use this for initialization
	void Start ()
	{
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
		animator.SetBool ("Walking", moveHorizontal != 0 || moveVertical != 0);
		if (moveHorizontal != 0 && moveHorizontal < 0 != facingRight) {
			flip ();
		}
		Vector3 movement = new Vector3 (Mathf.Abs(moveHorizontal), moveVertical, 0) * Time.deltaTime * speed;
		transform.Translate (movement);
	}

	private void flip() 
	{
		facingRight = !facingRight;
		Vector3 currentScale = transform.localScale;
		currentScale.x *= -1;
		transform.localScale = currentScale;
	}

}
