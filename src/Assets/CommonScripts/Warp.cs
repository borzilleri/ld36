using UnityEngine;

public class Warp : MonoBehaviour {

    public Transform warpTarget;

	void OnTriggerEnter2D(Collider2D collidee)
    {
        Debug.Log(string.Format("Object {0} collided", collidee.name));
        collidee.gameObject.transform.position = warpTarget.position;
        // Camera.main.transform.position = warpTarget.position;  // Use when camera follows player
    }
}
