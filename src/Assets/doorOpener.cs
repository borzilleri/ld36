using UnityEngine;
using System.Collections;

public class doorOpener : MonoBehaviour, UsableObject {

	public int openOffset;
	public float speed = 0.5f;

	private Vector3 openPosition;
	private Vector3 closePosition;

	//start the door closed
	private bool isClosed = true;
	private float fraction = 1;

	// Use this for initialization
	void Start () {
		openPosition = new Vector3 (transform.position.x, transform.position.y + openOffset, 0);
		closePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isClosed && fraction < 1) {
			fraction += Time.deltaTime * speed;
		} else if(!isClosed && fraction > 0) {
			fraction -= Time.deltaTime * speed;
		}
		transform.position = Vector3.Lerp (openPosition, closePosition, fraction);
	}

	void setDoorClosed(bool state) {
		isClosed = state;
	}

	public void Use( GameObject user) {
	}

	public void UseStart( GameObject user) {
		Debug.Log ("USE START IS BEING CALLED!!");
		setDoorClosed (false);
	}

	public void UseEnd( GameObject user) {
		Debug.Log ("USE END IS BEING CALLED!!");
		setDoorClosed (true);
	}

	public void Nearby(GameObject user) {
		Debug.Log ("NEARBY IS BEING CALLED!!");
	}

}
