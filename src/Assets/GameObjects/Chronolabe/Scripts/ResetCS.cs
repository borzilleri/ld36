using UnityEngine;
using System.Collections;

public class ResetCS : MonoBehaviour, UsableObject, EventListener
{
	Chronolabe labe;

	public Transform hourglass;
	private float hourglassRotation = 180;
	private float hourglassRotationTarget = 180;
	private float speed = 100;

	void Update()
	{
		if (null != hourglass && hourglassRotation <= hourglassRotationTarget) {
			Vector3 previousRotation = hourglass.eulerAngles;
			hourglassRotation += speed * Time.deltaTime;
			previousRotation.z = hourglassRotation;
			hourglass.eulerAngles = previousRotation;
		}
	}

	void Start ()
	{
		labe = GetComponentInParent<Chronolabe> ();
		EventManager.Instance.AddListener (Chronolabe.EVT_CHRONOLABE_RESET, gameObject);
	}

	public void UseStart (GameObject user)
	{
		labe.Reset ();
		if (hourglassRotation > 180) {
			hourglassRotation = 0;
			hourglassRotationTarget = 180;
		} else {
			hourglassRotation = 180;
			hourglassRotationTarget = 360;			
		}
	}

	public void UseEnd(GameObject user) {
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