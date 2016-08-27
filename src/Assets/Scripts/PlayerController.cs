using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public float speed;

	public PlayerFrameAction lastAction;
	bool isUsing;

	// Use this for initialization
	void Start ()
	{
		isUsing = false;
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("space")) {
			// Use whatever we're near.
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical) * speed;
		rb2d.AddForce (movement);

		lastAction = new PlayerFrameAction (movement, isUsing);
	}

	void LateUpdate() {

		// This is where we check for is recording, and push lastAction onto the current recording stack.
	}

	void OnTriggerEnter2D(Collider2D other) {
	}

	void OnTriggerExit2D(Collider2D other) {
	}
		
}
