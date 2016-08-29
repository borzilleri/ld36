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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setDoorOpen(bool open) {
		animator.Play (open ? "HiddenTempleDoorOpen" : "HiddenTempleDoorClose");
		bc2d.enabled = open;

		//play sound
		if (audio.isPlaying) {
			audio.Stop ();
		}
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

	string narration = @"Aletheia: There's no way I'm opening this thing by hand. These are supposed to be opened by some kind of mechanism though.
	
I always saw the scholars pressing this button to open the door, may as well try it...";
	
	public void Nearby (GameObject user) {
		if (!bc2d.enabled) {
			UISystem.Instance.NarrateInline (narration, 0.05f, 1f);
		}
	}
}

