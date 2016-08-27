using UnityEngine;
using System.Collections;

public class ZIndexSorter : MonoBehaviour {

	private BoxCollider2D collide2d;

	// Use this for initialization
	void Start () {
		calculateZ ();	
		collide2d = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		calculateZ ();
	}

	private void calculateZ()
	{
		if (collide2d == null) {
			return;
		}
		Vector3 pos = transform.position;
		pos.z = collide2d.bounds.max.y;
		transform.position = pos;		

	}
}
