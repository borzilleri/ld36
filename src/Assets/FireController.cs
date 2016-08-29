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

	public void UseStart (GameObject user) 
	{
		boiler.fire = true;
		if (!audio.isPlaying) {
			audio.Play ();
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
