using UnityEngine;
using System.Collections;

public class BoilerPipeController : MonoBehaviour, UsableObject {

	public void UseStart(GameObject user) {
		GetComponent<Animator> ().SetBool ("Fixed", true);
	}
	public void UseEnd(GameObject user) {
		GetComponent<Animator> ().SetBool ("Fixed", false);
	}
	public void Nearby(GameObject user) {
	}

}
