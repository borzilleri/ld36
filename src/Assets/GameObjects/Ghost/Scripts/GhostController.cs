using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhostController : MonoBehaviour {
	public static Object ghostPrefab;

	private Vector3 spawnPoint;
	private List<PlayerFrameAction> actions;
	private int count = 0;
	private Rigidbody2D rb2d;

	public static GhostController Create(List<PlayerFrameAction> actions, Vector3 spawn) {
		GameObject newObj = Instantiate (ghostPrefab) as GameObject;
		newObj.SetActive (false);
		GhostController ghost = newObj.GetComponent<GhostController> ();
		ghost.spawnPoint = spawn;
		ghost.actions = actions;
		return ghost;
	}

	public void Awake() {
		ghostPrefab = Resources.Load ("Prefabs/Ghost");
	}

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}

	public void Reset() {
		gameObject.SetActive (false);
		count = 0;
		gameObject.transform.position = spawnPoint;
	}

	public void AddAction(PlayerFrameAction action) {
		actions.Add (action);
	}


	void Update () {
		// TODO: Handle isUsing.
	}

	void FixedUpdate() {
		if (gameObject.activeSelf) {
			if (count <= actions.Count) {
				PlayerFrameAction action = actions [count];
				rb2d.AddForce (action.movement);
				count += 1;
			} else {
				Reset ();
			}
		}
	}
}
