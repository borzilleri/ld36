using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour, UsableObject {

	public BoilerMainController boiler;

	private Animator anim;
	private SpriteRenderer sprite;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		audio = GetComponent<AudioSource> ();
	}


	bool _narration = false;
	string narration = @"So this is what lit the fire…

It looks like I'll have to get all of this working at once. I'll need some help to keep the water and the fire on, though…";
		
	public void UseStart (GameObject user) 
	{
		boiler.fire = true;
		if (!audio.isPlaying) {
			audio.Play ();
		}
		if (!_narration) {
			UISystem.Instance.NarrateInline (narration, 0.05f, 1f);
		}
	}

	public void UseEnd (GameObject user) 
	{
		boiler.fire = false;
		audio.Stop ();
	}

	public void Nearby (GameObject user) 
	{

	}
}
