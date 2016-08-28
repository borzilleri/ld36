using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chronolabe : MonoBehaviour
{
	public static string EVT_CHRONOLABE_RESET = "chronolabeReset";
	public static string EVT_CHRONOLABE_REC_START = "labeRecordingStart";
	public static string EVT_CHRONOLABE_REC_STOP = "labeRecordingEnd";

	public int GhostFrameDuration;
	private List<PlayerController> ghosts;

	private bool _recording = false;

	public bool recording {
		get { return _recording; }
	}


	void Start ()
	{
		ghosts = new List<PlayerController> ();
		GhostFrameDuration = 60 * 5;
	}

	public void AddGhost (PlayerController ghost)
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
				ghost.Activate ();
			}
			user.GetComponent<PlayerController> ().StartRecording (GhostFrameDuration, this);
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
