using UnityEngine;
using System.Collections;

public class ActivateCS : MonoBehaviour, UsableObject
{
	Chronolabe labe;

	// Use this for initialization
	void Start ()
	{
		labe = GetComponentInParent<Chronolabe> ();
	}

	public void Use (GameObject user)
	{
		UISystem.Instance.NarrateInline ("Lorem ipsum dolor sit amet,\nconsectetur adipiscing elit.\n\nIn id nisi in mi porttitor sagittis et at massa.", 0.1f, 3f);
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
}
