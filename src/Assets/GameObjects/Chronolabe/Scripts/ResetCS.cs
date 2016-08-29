using UnityEngine;
using System.Collections;

public class ResetCS : MonoBehaviour, UsableObject, EventListener
{
	Chronolabe labe;

	void Start ()
	{
		labe = GetComponentInParent<Chronolabe> ();
		EventManager.Instance.AddListener (Chronolabe.EVT_CHRONOLABE_RESET, gameObject);
	}

	public void Use (GameObject user)
	{
		labe.Reset ();
	}

	public void Nearby (GameObject user)
	{
	}

	public string GetTooltip ()
	{
		return labe.recording ? "" : "Use: Erase your recorded actions.";
	}

	private bool _resetting = false;

	private IEnumerator animateReset ()
	{
		_resetting = true;
		GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (2);
		_resetting = false;
	}

	public void ReceiveEvent (EventMessage evt)
	{
		switch (evt.type) {
		case Chronolabe.EVT_CHRONOLABE_RESET:
			if (!_resetting) {
				StartCoroutine (animateReset ());
			}
			break;
		default:
			break;
		}

	}
}