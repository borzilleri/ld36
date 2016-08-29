using UnityEngine;
using System.Collections;

public class ActivateCS : MonoBehaviour, UsableObject, EventListener
{
	Chronolabe labe;

	// Use this for initialization
	void Start ()
	{
		labe = GetComponentInParent<Chronolabe> ();
		EventManager.Instance.AddListener (Chronolabe.EVT_CHRONOLABE_REC_START, gameObject);
		EventManager.Instance.AddListener (Chronolabe.EVT_CHRONOLABE_REC_STOP, gameObject);
	}

	public void Use (GameObject user)
	{
		Debug.Log ("Chronolabe: Activated");
		labe.StartRecording (user);
	}

	public void Nearby (GameObject user)
	{
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
