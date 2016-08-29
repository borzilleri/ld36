using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(GhostController))]
public class UsageController : MonoBehaviour
{
	private bool isUsing = false;
	private bool startedUsing = false;
	private bool stoppedUsing = false;

	private GhostController _input;
	private UsableObjectCS collidingWith = null;

	void Awake ()
	{
		_input = GetComponent<GhostController> ();
	}

	void Update ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			startedUsing = _input.GetKeyDown (KeyCode.Space);
			stoppedUsing = _input.GetKeyUp (KeyCode.Space);
			isUsing = _input.GetKey (KeyCode.Space);
		}
	}

	void LateUpdate ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			if (null != collidingWith) {
				if (startedUsing) {
					isUsing = true;
					collidingWith.StartUsing (gameObject);
				} else if (stoppedUsing) {
					isUsing = false;
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
		if ( isUsing && null != collidingWith) {
			collidingWith.StopUsing (gameObject);
		}
		collidingWith = null;
	}
}