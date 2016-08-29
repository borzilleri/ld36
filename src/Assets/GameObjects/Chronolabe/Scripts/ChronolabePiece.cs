using UnityEngine;
using System.Collections;

public class ChronolabePiece : MonoBehaviour, UsableObject {
	public void UseStart(GameObject user) {
	}
	public void UseEnd(GameObject user) {
	}
	public void Nearby(GameObject user) {
		UISystem.Instance.NarrateInline ("Aletheia: This looks like the missing piece!", 0f, 1.5f);


	}
}
