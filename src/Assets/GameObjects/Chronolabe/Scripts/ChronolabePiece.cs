using UnityEngine;
using System.Collections;

public class ChronolabePiece : MonoBehaviour, UsableObject {
	public void UseStart(GameObject user) {
	}

	public void UseEnd(GameObject user) {
	}

	string narration = @"Aletheia: Here it is! I can fix the chronolabe with this!";
	public void Nearby(GameObject user) {
		UISystem.Instance.NarrateInline (narration, 0f, 1.5f);
	}
}
