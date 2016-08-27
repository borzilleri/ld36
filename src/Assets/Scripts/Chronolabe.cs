using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chronolabe : MonoBehaviour, UsableObject
{
	public int Duration;

	int recordingCount = 0;

	bool isRecording = false;
	bool doSpawn = false;

	List<GhostController> ghosts;

	PlayerController user;
	Vector3 currentSpawn;
	List<PlayerFrameAction> currentActions;
	
	// Use this for initialization
	void Start ()
	{
		ghosts = new List<GhostController> ();
		Duration = 60 * 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (doSpawn) {
			currentSpawn = user.transform.position;
			currentActions = new List<PlayerFrameAction> ();

			// Activate Existing Ghosts.
			foreach (var ghost in ghosts) {
				ghost.gameObject.SetActive (true);
			}
			doSpawn = false;
		}
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
			doSpawn = true;

			this.user = user.GetComponent<PlayerController>();
		}
	}
}
