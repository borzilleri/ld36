using UnityEngine;
using System.Collections;

public class ResetCS : MonoBehaviour, UsableObject {
	Chronolabe labe;

	void Start () {
		labe = GetComponentInParent<Chronolabe> ();
	}
	
	public void Use(GameObject user) {
		labe.Reset ();
	}


	public void Nearby(GameObject user) {
	}

	public string GetTooltip() {
		return labe.recording ? "" : "Use: Erase your recorded actions.";
	}

}
