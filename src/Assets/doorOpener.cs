using UnityEngine;
using System.Collections;

public class doorOpener : MonoBehaviour, UsableObject {

	public int openOffset;
	private bool open = false;
	public float speed = 0.5f;

	private Vector3 openPosition;
	private Vector3 closePosition;
	private float fraction = 0;

	// Use this for initialization
	void Start () {
		openPosition = new Vector3 (transform.position.x, transform.position.y + openOffset, 0);
		closePosition = transform.position;
//		setDoorState (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (fraction < 1) {
			fraction += Time.deltaTime * speed;
			if (open) {
				transform.position = Vector3.Lerp (closePosition, openPosition, fraction);
			} else {
				transform.position = Vector3.Lerp (openPosition, closePosition, fraction);
			}

		}
	}

	void setDoorState(bool state) {
		open = state;
		fraction = 0;
	}

	void Use( GameObject user) {
		setDoorState (true);
	}

	void Nearby(GameObject user) {
		
	}
}
