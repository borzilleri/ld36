using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chronolabe : MonoBehaviour, UsableObject
{
	public int Duration;

	private bool isRecording = false;
	List<PlayerController> ghosts;

	void Start ()
	{
		ghosts = new List<PlayerController> ();
		Duration = 60 * 5;
	}
	
	public void AddGhost(PlayerController ghost) {
		Debug.Log ("Adding Ghost to Chronolabe");	
		ghosts.Add (ghost);
		this.isRecording = false;
		UISystem.Instance.DisplayCutScene ("Lorem ipsum dolor sit amet,\nconsectetur adipiscing elit.\n\nIn id nisi in mi porttitor sagittis et at massa.", 6f);
	}

	void StartRecording(GameObject user) {
		Debug.Log ("Activating chronolabe");
		isRecording = true;
		foreach (var ghost in ghosts) {
			ghost.Activate ();
		}
		user.GetComponent<PlayerController>().StartRecording(Duration, this);
	}

	public void Use (GameObject user)
	{
		UISystem.Instance.NarrateInline ("Lorem ipsum dolor sit amet,\nconsectetur adipiscing elit.\n\nIn id nisi in mi porttitor sagittis et at massa.", 3f);
		Debug.Log ("Use: chronolabe");
		if (!isRecording) {
			StartRecording (user);
		}
	}

	public void Nearby(GameObject user) {
		UISystem.Instance.NarrateInline ("Aletheia: This looks fun!", 0.5f);
	}

	public string GetTooltip() {
		return "Use the Chronolabe to record your actions.";
	}

}
