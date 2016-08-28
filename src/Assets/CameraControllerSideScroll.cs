using UnityEngine;
using System.Collections;

public class CameraControllerSideScroll : MonoBehaviour {

	public Transform playerTransform;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - playerTransform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 targetPosition = playerTransform.position + offset;
//		targetPosition.x += offset.x;
		transform.position = targetPosition;
	}
}
