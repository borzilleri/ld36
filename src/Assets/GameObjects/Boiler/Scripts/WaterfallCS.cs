using UnityEngine;
using System.Collections;

public class WaterfallCS : MonoBehaviour, UsableObject {

	public void UseStart (GameObject user) {
		GetComponent<SpriteRenderer> ().enabled = true;
	}

	public void UseEnd(GameObject user) {
		GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void Nearby(GameObject user) {
	}
}
