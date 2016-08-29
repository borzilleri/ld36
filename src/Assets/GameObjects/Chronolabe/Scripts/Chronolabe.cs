using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chronolabe : MonoBehaviour
{
	public const string EVT_CHRONOLABE_RESET = "chronolabeReset";
	public const string EVT_CHRONOLABE_REC_START = "labeRecordingStart";
	public const string EVT_CHRONOLABE_REC_STOP = "labeRecordingEnd";

	public int ghostDurationSeconds = 3;

	private List<GhostController> ghosts;

	private bool _recording = false;

	public bool recording {
		get { return _recording; }
	}

	bool _wipeAfterRecording = false;

	void Start ()
	{
		ghosts = new List<GhostController> ();
	}

	public void WarpComplete ()
	{
		_wipeAfterRecording = true;
		/*
		if (recording) {
			EventManager.Instance.DispatchEvent (new EventMessage (EVT_CHRONOLABE_REC_STOP));
			_recording = false;
		}
		foreach (GhostController ghost in ghosts) {
			Destroy (ghost.gameObject);
		}
		ghosts.Clear ();
		*/
	}

	public void AddGhost (GhostController ghost)
	{
		if (recording) {
			Debug.Log ("Adding Ghost to Chronolabe");
			ghosts.Add (ghost);
			EventManager.Instance.DispatchEvent (new EventMessage (EVT_CHRONOLABE_REC_STOP));
			_recording = false;

			if (_wipeAfterRecording) {
				Reset ();
				_wipeAfterRecording = false;
			}
		}
	}

	public void StartRecording (GameObject user)
	{
		if (!_recording) {
			Debug.Log ("Activating chronolabe");
			_recording = true;
			foreach (var ghost in ghosts) {
				ghost.StartPlayback ();
			}
			user.GetComponent<GhostController> ().StartRecording (ghostDurationSeconds * 60, this);
			EventManager.Instance.DispatchEvent (new EventMessage (EVT_CHRONOLABE_REC_START));
		}
	}

	public void Reset ()
	{
		if (!recording) {
			foreach (GhostController ghost in ghosts) {
				Destroy (ghost.gameObject);
			}
			ghosts = new List<GhostController> ();
		}
	}
}
