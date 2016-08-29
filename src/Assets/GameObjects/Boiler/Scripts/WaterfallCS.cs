using UnityEngine;
using System.Collections;

public class WaterfallCS : MonoBehaviour, UsableObject {

	public int openOffset;

	private Vector3 openPosition;
	private Vector3 closePosition;

	//Pulled code from the door controller to get a water falling effect
	//totally not perfect but nothing is
	private bool isClosed = false;
	private float fraction = 0;
	private int speed = 5;
	private SpriteRenderer spriteRenderer;

	void Start() {
		openPosition = new Vector3 (transform.position.x, transform.position.y + openOffset, 0);
		closePosition = transform.position;	
		spriteRenderer = GetComponent<SpriteRenderer> ();
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

	public void UseStart (GameObject user) {
		spriteRenderer.enabled = true;
		isClosed = true;
	}

	public void UseEnd(GameObject user) {
		spriteRenderer.enabled = false;
		isClosed = false;
	}

	public void Nearby(GameObject user) {
	}
}
