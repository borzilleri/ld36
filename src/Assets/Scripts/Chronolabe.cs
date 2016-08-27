using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chronolabe : MonoBehaviour, UsableObject
{
	public int Duration;

	int recordingCount = 0;

	bool isRecording = false;
	bool doSpawn = false;

	List<PlayerController> ghosts;

	PlayerController user;
	Vector3 currentSpawn;
	List<PlayerFrameAction> currentActions;
	
	// Use this for initialization
	void Start ()
	{
		ghosts = new List<GhostController> ();
		Duration = 60 * 10;
	}
	
	void Update ()
	{
	}

	void LateUpdate ()
	{
		if (isRecording) {
			if (recordingCount > Duration) {
				isRecording = false;
				recordingCount = 0;
				ghosts.Add (GhostController.Create (currentActions, currentSpawn));
				user = null;
			} else {
				currentActions.Add (user.lastAction);
				recordingCount += 1;
			}
		}
	}

	public void Use (GameObject user)
	{
		if (!isRecording) {
			isRecording = true;
			foreach (var ghost in ghosts) {
				ghost.Activate ();
			}
			this.user = user.GetComponent<PlayerController>();
			this.user.StartRecording(Duration);
		}
	}
}
