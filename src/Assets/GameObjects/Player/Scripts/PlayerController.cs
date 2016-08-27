using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	public static Object ghostPrefab;

	private Vector3 spawnPoint;
	private PlayerFrameAction[] actions;
	private int actionCount = 0;
	private bool isRecording = false;

	private Rigidbody2D rb2d;
	public float speed;

	public PlayerFrameAction lastAction;

	bool isUsing;
	public bool isGhost = false;

//	public static PlayerController CreateGhost (List<PlayerFrameAction> actions, Vector3 spawn)
//	{
//		GameObject newObj = Instantiate (ghostPrefab) as GameObject;
//		newObj.SetActive (false);
//		GhostController ghost = newObj.GetComponent<GhostController> ();
//		ghost.spawnPoint = spawn;
//		ghost.actions = actions;
//		return ghost;
//	}

	void Awake ()
	{
		ghostPrefab = Resources.Load ("Prefabs/Player");
	}

	// Use this for initialization
	void Start ()
	{
		isUsing = false;
		rb2d = GetComponent<Rigidbody2D> ();
	}

	public void StartRecording (int duration)
	{
		actions = new PlayerFrameAction[duration];
		actionCount = 0;
		spawnPoint = gameObject.transform.position;
		isRecording = true;
	}

	public void Activate() {
		gameObject.SetActive (true);
	}

	public void Reset() {
		gameObject.SetActive (false);
		actionCount = 0;
		gameObject.transform.position = spawnPoint;
	}
	
	void Update ()
	{
//		lastAction = new PlayerFrameAction ();
//
//		if (isGhost) {
//			if (gameObject.activeSelf && actionCount <= actions.Count) {
//				isUsing = actions [actionCount].isUsing;
//			}
//		} else {
//			isUsing = Input.GetButton ("space");
//			lastAction.isUsing = isUsing;
//		}
	}

	void FixedUpdate ()
	{
//		Vector2 movement;
//		if (isGhost ) {
//			if( gameObject.activeSelf && actionCount <= actions.Count) {
//				movement = actions [actionCount].movement;
//			}
//		} else {
//			float moveHorizontal = Input.GetAxis ("Horizontal");
//			float moveVertical = Input.GetAxis ("Vertical");
//			movement = new Vector2 (moveHorizontal, moveVertical) * speed;
//			if (isRecording) {
//				lastAction.movement = movement;
//			}
//		}
//		rb2d.AddForce (movement);
//	}
//
//	void LateUpdate ()
//	{
//		if (isRecording) {
//			actions [actionCount] = lastAction;
//			// Do we need to stop recording?
//			if (actionCount == actions.GetLength - 1) {
//			}
//		}
//		if (isGhost && gameObject.activeSelf && actionCount >= actions.GetLength) {
//			// We're done with playback, reset 
//			Reset();
//		}
//		actionCount += 1;
//
//		if (isUsing) {
//			// Use whatever collider we're near.
//		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
	}

	void OnTriggerExit2D (Collider2D other)
	{
//		other.gameObject.GetComponent ();
	}
		
}
