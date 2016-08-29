using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chronolabe : MonoBehaviour
{
	public const string EVT_CHRONOLABE_RESET = "chronolabeReset";
	public const string EVT_CHRONOLABE_REC_START = "labeRecordingStart";
	public const string EVT_CHRONOLABE_REC_STOP = "labeRecordingEnd";

	public int ghostDurationSeconds = 3;

	private AudioSource audio;
	private List<GhostController> ghosts;

	private bool _recording = false;

	public bool recording {
		get { return _recording; }
	}

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		ghosts = new List<GhostController> ();
	}

	void LateUpdate()
	{
		if (!recording && audio.isPlaying) {
			audio.Stop ();
		}
	}

	public void WarpComplete() {
		Reset ();
	}

	public void AddGhost (GhostController ghost)
	{
		if (_recording) {
			Debug.Log ("Adding Ghost to Chronolabe");
			ghosts.Add (ghost);
		}
		EventManager.Instance.DispatchEvent (new EventMessage (EVT_CHRONOLABE_REC_STOP));
		_recording = false;
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
			audio.Play ();
		}
	}

	public void Reset() {
		_recording = false;
		foreach (GhostController ghost in ghosts) {
			Destroy (ghost.gameObject);
		}
		ghosts.Clear ();
	}
}
