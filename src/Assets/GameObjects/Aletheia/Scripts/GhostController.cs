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
	PlayerFrameAction[] frameActions;
	Vector3 spawnPoint;

	PlayerMovement[] transforms;
	PlayerAction[] actions;

	private Chronolabe chronolabe;

	public GhostController CreateGhost ()
	{
		GameObject newObj = Instantiate (gameObject) as GameObject;
		newObj.SetActive (false);
		GhostController ghost = newObj.GetComponent<GhostController> ();
		ghost._isGhost = true;
		ghost.spawnPoint = spawnPoint;
		ghost.frameActions = frameActions.Clone () as PlayerFrameAction[];
		ghost.transforms = transforms.Clone () as PlayerMovement[];
		ghost.actions = actions.Clone () as PlayerAction[];
		return ghost;
	}

	public void StopRecording ()
	{
		Debug.LogFormat ("Finished recording {0} frames", actionCount);
		isRecording = false;
		Chronolabe labe = chronolabe;
		chronolabe = null;
		labe.AddGhost (CreateGhost ());
	}

	public void StartRecording (int frames, Chronolabe labe)
	{
		Debug.LogFormat ("Starting to record {0} frames", frames);
		chronolabe = labe;
		isRecording = true;
		actionCount = 0;
		frameActions = new PlayerFrameAction[frames];
		transforms = new PlayerMovement[frames];
		actions = new PlayerAction[frames];
		spawnPoint = gameObject.transform.position;
	}

	public void StartPlayback ()
	{
		if (_isGhost) {
			Debug.LogFormat ("Beginning Playback of at {0} with {1} frames", spawnPoint.ToString (), frameActions.Length);
			actionCount = 0;
			gameObject.SetActive (true);
			gameObject.transform.position = spawnPoint;
		}
	}

	public void StopPlayback ()
	{
		if (_isGhost) {
			Debug.Log ("Stopping playback");
			GetComponent<UsageController> ().ForceTriggerExit ();
			gameObject.SetActive (false);
		}
	}

	public bool isPlayback {
		get { return _isGhost && gameObject.activeSelf; }
	}

	public void RecordMovement (PlayerMovement action)
	{
		if (isRecording) {
			transforms [actionCount] = action;
		}
	}

	public void RecordAction (PlayerAction action)
	{
		if (isRecording) {
			actions [actionCount] = action;
		}
	}

	public PlayerMovement GetRecordedMovement ()
	{
		if (actionCount < transforms.Length) {
			return transforms [actionCount];
		}
		return PlayerMovement.zero;
	}

	public PlayerAction GetRecordedAction ()
	{
		if (actionCount < actions.Length) {
			return actions [actionCount];
		}
		return PlayerAction.None;
	}

	void FixedUpdate ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			if (isRecording) {
				PlayerFrameAction action = new PlayerFrameAction ();
				action.SetKeyStateFromInput (KeyCode.Space);
				action.SetKeyStateFromInput (KeyCode.UpArrow);
				action.SetKeyStateFromInput (KeyCode.DownArrow);
				action.SetKeyStateFromInput (KeyCode.LeftArrow);
				action.SetKeyStateFromInput (KeyCode.RightArrow);

				frameActions [actionCount] = action;
			}

			if (isPlayback || isRecording) {
				actionCount += 1;
			}

			if (frameActions != null && actionCount >= frameActions.Length) {
				if (isRecording)
					StopRecording ();
				if (isPlayback)
					StopPlayback ();
			}
		}
	}

	public bool GetKey (KeyCode key)
	{
		if (UISystem.Instance.CutSceneDisplaying ())
			return false;
		if (isGhost) {
			return isPlayback ? frameActions [actionCount].GetKey (key) : false;
		}
		return Input.GetKey (key);
	}

	public bool GetKeyDown (KeyCode key)
	{
		if (UISystem.Instance.CutSceneDisplaying ())
			return false;
		if (isGhost) {
			return isPlayback ? frameActions [actionCount].GetKeyDown (key) : false;
		}
		return Input.GetKey (key);
	}

	public bool GetKeyUp (KeyCode key)
	{
		if (UISystem.Instance.CutSceneDisplaying ())
			return false;
		if (isGhost) {
			return isPlayback ? frameActions [actionCount].GetKeyUp (key) : false;
		}
		return Input.GetKeyUp (key);
	}
}

