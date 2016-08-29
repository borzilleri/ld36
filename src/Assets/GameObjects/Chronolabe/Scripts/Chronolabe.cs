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

	void Start ()
	{
		ghosts = new List<GhostController> ();
	}

	public void AddGhost (GhostController ghost)
	{
		Debug.Log ("Adding Ghost to Chronolabe");	
		ghosts.Add (ghost);
		_recording = false;
		EventManager.Instance.DispatchEvent (new EventMessage (EVT_CHRONOLABE_REC_STOP));
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

	public void Reset() {
		if (!_recording) {
			EventManager.Instance.DispatchEvent (new EventMessage (EVT_CHRONOLABE_RESET));
			ghosts.Clear ();
		}
	}
}
