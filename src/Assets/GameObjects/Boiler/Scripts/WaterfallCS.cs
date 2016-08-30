using UnityEngine;
using System.Collections;

public class WaterfallCS : MonoBehaviour, UsableObject
{

	public BoilerMainController boiler;

	private AudioSource audio;


	void Start ()
	{
		audio = GetComponent<AudioSource> ();
	}

	bool _narration = false;
	string narration = "Aletheia: Oh! There's water! That's what that pipe was for. Something's wrong, the door isn't opening. I'd better go down and see if the mechanism is damaged.";

	public void UseStart (GameObject user)
	{
		boiler.water = true;
		if (!audio.isPlaying) {
			audio.Play ();
		}
		if (!_narration) {
			UISystem.Instance.NarrateInline (narration, 0.05f, 1f);
			_narration = true;
		}
	}

	public void UseEnd (GameObject user)
	{
		boiler.water = false;
		audio.Stop ();
	}

	public void Nearby (GameObject user)
	{
	}
}
