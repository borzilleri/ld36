using UnityEngine;
using System.Collections;

public class respawner : MonoBehaviour {

	public Transform spawnTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("RESPAWN");
		other.transform.position = spawnTarget.transform.position;
	}
}
