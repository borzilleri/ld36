using UnityEngine;
using System.Collections;

public class WaterfallCS : MonoBehaviour, UsableObject {

	public BoilerMainController boiler;

	private AudioSource audio;


	void Start() {
		audio = GetComponent<AudioSource> ();
	}

	public void UseStart (GameObject user) {
		boiler.water = true;
		if (!audio.isPlaying) {
			audio.Play ();
		}

	}

	public void UseEnd(GameObject user) {
		boiler.water = false;
		audio.Stop ();
	}

	public void Nearby(GameObject user) {
	}
}
