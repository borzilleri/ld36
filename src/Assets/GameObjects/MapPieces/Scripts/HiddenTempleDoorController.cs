using UnityEngine;
using System.Collections;

public class HiddenTempleDoorController : MonoBehaviour, UsableObject {

//	private bool isOpen = false;
	private Animator animator;
	private BoxCollider2D bc2d;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		bc2d = GetComponent<BoxCollider2D> ();
		audio = GetComponent<AudioSource> ();
//		setDoorOpen (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setDoorOpen(bool open) {
		animator.Play (open ? "HiddenTempleDoorOpen" : "HiddenTempleDoorClose");
		bc2d.enabled = open;

		//play sound
		if (audio.isPlaying) {
			audio.Stop ();
		}
		//sound clip is too long (ain't nobody got time to edit audio files)
		audio.time = 0.6f;
		audio.Play ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("and aawwaaaay we go!!!");
	}

	public void UseStart (GameObject user) {
	}

	public void UseEnd (GameObject user) {
		setDoorOpen (!bc2d.enabled);
	}

	public void Nearby (GameObject user) {
	}
}

