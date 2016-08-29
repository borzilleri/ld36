using UnityEngine;
using System.Collections.Generic;

public class GhostController : MonoBehaviour
{
	bool _isGhost = false;
	bool isRecording = false;

	public bool isGhost {
		get { return _isGhost; }
	}

	int actionCount;
	PlayerFrameAction[] actions;
	Vector3 spawnPoint;

	private Chronolabe chronolabe;

	public GhostController CreateGhost (PlayerFrameAction[] actions, Vector3 spawn) {
		GameObject newObj = Instantiate (gameObject) as GameObject;
		newObj.SetActive (false);
		GhostController ghost = newObj.GetComponent<GhostController> ();
		ghost._isGhost = true;
		ghost.actions = actions;
		ghost.spawnPoint = spawn;
		return ghost;
	}

	public void StopRecording ()
	{
		Debug.LogFormat ("Finished recording {0} frames", actionCount);
		isRecording = false;
		Chronolabe labe = chronolabe;
		chronolabe = null;
		labe.AddGhost (CreateGhost (actions, spawnPoint));
	}

	public void StartRecording (int frames, Chronolabe labe)
	{
		Debug.LogFormat ("Starting to record {0} frames", frames);
		chronolabe = labe;
		isRecording = true;
		actionCount = 0;
		actions = new PlayerFrameAction[frames];
		spawnPoint = gameObject.transform.position;
	}

	public void StartPlayback ()
	{
		if (_isGhost) {
			Debug.LogFormat ("Beginning Playback of {0} frames", actionCount);
			actionCount = 0;
			gameObject.SetActive (true);
		}
	}

	public void StopPlayback ()
	{
		if (_isGhost) {
			Debug.Log ("Stopping playback");
			gameObject.SetActive (false);
			gameObject.transform.position = spawnPoint;
		}
	}

	public bool isPlayback {
		get { return _isGhost && gameObject.activeSelf; }
	}

	void LateUpdate ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			Debug.Log ("In lastupdate");
			if (isRecording) {
				Debug.LogFormat ("Recording frame: {0}", actionCount);
				PlayerFrameAction action = new PlayerFrameAction ();
				action.SetKeyStateFromInput (KeyCode.Space);
				action.SetKeyStateFromInput (KeyCode.UpArrow);
				action.SetKeyStateFromInput (KeyCode.DownArrow);
				action.SetKeyStateFromInput (KeyCode.LeftArrow);
				action.SetKeyStateFromInput (KeyCode.RightArrow);

				actions [actionCount] = action;
			}

			if (isPlayback || isRecording) {
				actionCount += 1;
			}

			if (actionCount >= actions.Length) {
				if (isRecording)
					StopRecording ();
				if (isPlayback)
					StopPlayback ();
			}
		}
	}

	public bool GetKey (KeyCode key)
	{
		return isPlayback ? actions [actionCount].GetKey (key) : Input.GetKey (key);
	}

	public bool GetKeyDown (KeyCode key)
	{
		return isPlayback ? actions [actionCount].GetKeyDown (key) : Input.GetKeyDown (key);
	}

	public bool GetKeyUp (KeyCode key)
	{
		return isPlayback ? actions [actionCount].GetKeyUp (key) : Input.GetKeyUp (key);
	}
}

