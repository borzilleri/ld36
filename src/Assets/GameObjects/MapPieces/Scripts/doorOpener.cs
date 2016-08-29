using UnityEngine;
using System.Collections;

/**
 * Controls opening / closing of door
 * Transform should be set in the closed position
 * The openOffset should be the amount the door needs to move on the Y axis to be open
 * if "open" is set to true the door will start in the open state when the scene loads
 */
public class doorOpener : MonoBehaviour, UsableObject {

	public int openOffset;
	public float speed = 0.5f;
	public bool open = false;

	private AudioSource audio;
	private Vector3 openPosition;
	private Vector3 closePosition;

	//start the door closed
	private bool previousIsClosed = true;
	private bool isClosed = true;
	private float fraction = 1;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		openPosition = new Vector3 (transform.position.x, transform.position.y + openOffset, 0);
		closePosition = transform.position;
		if (open) {
			transform.position = openPosition;
			isClosed = false;
			fraction = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isClosed && fraction < 1) {
			fraction += Time.deltaTime * speed;
		} else if(!isClosed && fraction > 0) {
			fraction -= Time.deltaTime * speed;
		}
		transform.position = Vector3.Lerp (openPosition, closePosition, fraction);

		if (previousIsClosed != isClosed) {
			//play sound
			if (audio.isPlaying) {
				audio.Stop ();
			}
			//sound clip is too long (ain't nobody got time to edit audio files)
			audio.time = 0.5f;
			audio.Play ();		

		}
		previousIsClosed = isClosed;
	}

	void setDoorClosed(bool state) {
		isClosed = state;


	}

	public void UseStart( GameObject user) {
//		Debug.Log ("USE START IS BEING CALLED!!");
		setDoorClosed (false);
	}

	public void UseEnd( GameObject user) {
//		Debug.Log ("USE END IS BEING CALLED!!");
		setDoorClosed (true);
	}

	public void Nearby(GameObject user) {
//		Debug.Log ("NEARBY IS BEING CALLED!!");
	}

}
