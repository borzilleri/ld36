using UnityEngine;
using System.Collections;

public class HiddenTempleDoorController : MonoBehaviour {

	private bool isOpen = false;
	private Animator animator;
	private BoxCollider2D bc2d;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		bc2d = GetComponent<BoxCollider2D> ();
//		setDoorOpen (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setDoorOpen(bool open) {
		animator.Play (open ? "HiddenTempleDoorOpen" : "HiddenTempleDoorClose");
		bc2d.enabled = open;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("and aawwaaaay we go!!!");
	}
}

