using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chronolabe : MonoBehaviour, UsableObject
{
	public int Duration;

	private bool isRecording = false;
	List<PlayerController> ghosts;

	// Use this for initialization
	void Start ()
	{
		ghosts = new List<PlayerController> ();
		Duration = 60 * 5;
	}
	
	public void AddGhost(PlayerController ghost) {
		Debug.Log ("Adding Ghost to Chronolabe");	
		ghosts.Add (ghost);
		this.isRecording = false;
	}

	public void Use (GameObject user)
	{
		Debug.Log ("Use: chronolabe");
		if (!isRecording) {
			Debug.Log ("Activating chronolabe");
			isRecording = true;
			foreach (var ghost in ghosts) {
				ghost.Activate ();
			}
			user.GetComponent<PlayerController>().StartRecording(Duration, this);
		}
	}
}
