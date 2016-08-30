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
		string _endNarration = @"Aletheia proceeds inside the Musaeum. It is a shadow of its former glory: moldy bookshelves lie in piles of rubble, their scrolls ruined. The building appears to have been torn in half, its walls leaning on one another for support rather than existing as a single solid structure. The mosaics and murals have all worn away to pale ghosts.

Fortunately, she finds a set of intact scrolls with the information she needs. Unfurling them, she studies their schematics and learns the configuration she needs to set the chronolabe to in order to enable time travel.

It is clear to Aletheia what she needs to do. She hopes that the rest of the village is intact enough – or the time-warps accommodating enough – that she can acquire what she needs and get home.";

		UISystem.Instance.DisplayCutScene (_endNarration, 0.02f, 3f, "Title");
		
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

