using UnityEngine;
using System.Collections;

public class ActivateCS : MonoBehaviour, UsableObject, EventListener
{
	Chronolabe labe;
	private AudioSource audio;

	// Use this for initialization
	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		labe = GetComponentInParent<Chronolabe> ();
		EventManager.Instance.AddListener (Chronolabe.EVT_CHRONOLABE_REC_START, gameObject);
		EventManager.Instance.AddListener (Chronolabe.EVT_CHRONOLABE_REC_STOP, gameObject);
	}


	string narration = @"Yes! I can use this to get past the door! I just need to press the button and then come back and activate the chronolabe again.";
	bool _narration = false;
	public void UseStart (GameObject user)
	{
		labe.StartRecording (user);
		if (!audio.isPlaying) {
			audio.Play ();
		}
		if (!_narration) {
			UISystem.Instance.NarrateInline (narration, 0f, 1f);
			_narration = true;
		}
	}

	public void UseEnd (GameObject user)
	{
	}

	void LateUpdate ()
	{
		if (!labe.recording && audio.isPlaying) {
			audio.Stop ();
		}
	}

	public void Nearby (GameObject user)
	{
		//UISystem.Instance.SetTooltip ("test");
	}

	public string GetTooltip ()
	{
		return labe.recording ? "" : "Use: Create a new record of your actions.";
	}

	public void ReceiveEvent (EventMessage evt)
	{
		switch (evt.type) {
		case Chronolabe.EVT_CHRONOLABE_REC_START:
			GetComponent<ParticleSystem> ().Play ();
			break;
		case Chronolabe.EVT_CHRONOLABE_REC_STOP:
			GetComponent<ParticleSystem> ().Stop ();
			break;
		default:
			break;
		}
	}
}
