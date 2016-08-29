using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UsageController : MonoBehaviour
{
	private Rigidbody2D rb2d;

	private UsableObjectCS collidingWith = null;

	private bool startedUsing = false;
	private bool stoppedUsing = false;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			startedUsing = Input.GetButtonDown ("Action");
			stoppedUsing = Input.GetButtonUp ("Action");
		}
	}

	void LateUpdate ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			if (null != collidingWith) {
				if (startedUsing) {
					collidingWith.StartUsing (gameObject);
				} else if (stoppedUsing) {
					collidingWith.StopUsing (gameObject);
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		collidingWith = other.gameObject.GetComponent<UsableObjectCS> ();
		if (null != collidingWith) {
			Debug.Log ("Colliding with usable object.");
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		collidingWith = null;
	}
}