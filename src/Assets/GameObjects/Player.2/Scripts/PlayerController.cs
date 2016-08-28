using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
	public GameObject ghostPrefab;

	private Vector3 spawnPoint;
	private PlayerFrameAction[] actions;
	private int actionCount = 0;
	private bool isRecording = false;

	private Rigidbody2D rb2d;
	public float speed;

	public PlayerFrameAction lastAction;

	bool isUsing;
	public bool isGhost = false;

	public Chronolabe chronolabe;

	private UsableObjectCS collidingWith = null;

	private Animator animator;
	private bool facingRight;
	private string animationState;

	public PlayerController CreateGhost (PlayerFrameAction[] actions, Vector3 spawn)
	{
		GameObject newObj = Instantiate (ghostPrefab) as GameObject;
		PlayerController ghost = newObj.GetComponent<PlayerController> ();
		ghost.isGhost = true;
		ghost.actions = actions;
		ghost.spawnPoint = spawn;
		ghost.Reset ();
		return ghost;
	}

	void Awake ()
	{
		Debug.Log ("Loading Player prefab");
		//ghostPrefab = Resources.Load ("Assets/GameObjects/Player/Player");
	}

	// Use this for initialization
	void Start ()
	{
		isUsing = false;
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		facingRight = false;
	}

	public void StartRecording (int duration, Chronolabe labe)
	{
		this.chronolabe = labe;
		actions = new PlayerFrameAction[duration];
		actionCount = 0;
		spawnPoint = gameObject.transform.position;
		isRecording = true;
	}

	public void StopRecording ()
	{
		Chronolabe labe = this.chronolabe;
		this.chronolabe = null;
		labe.AddGhost (CreateGhost (actions, spawnPoint));
		isRecording = false;
	}

	public void Activate ()
	{
		Debug.Log ("Activaing ghost.");
		gameObject.SetActive (true);
	}

	public void Reset ()
	{
		gameObject.SetActive (false);
		actionCount = 0;
		gameObject.transform.position = spawnPoint;
	}

	void Update ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			if (isGhost) {
				if (gameObject.activeSelf && actionCount < actions.Length) {
					isUsing = actions [actionCount].isUsing;
				}
			} else {
				isUsing = Input.GetButton ("Action");
				lastAction.isUsing = isUsing;
			}
		}
	}

	void FixedUpdate ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			
			Vector2 movement = Vector2.zero;
			if (isGhost) {
				if (gameObject.activeSelf && actionCount < actions.Length) {
					movement = actions [actionCount].movement;
				}
			} else {
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
				if (Input.GetKeyDown ("space")) {
					setAnimation ("Attack");
				} else if (moveHorizontal == 0 && moveVertical == 0) {
					setAnimation ("Idle");
				} else {
					setAnimation ("Walk");
					if (moveHorizontal > 0 != facingRight) {
						flip ();
					}
				}
				movement = new Vector2 (moveHorizontal, moveVertical) * speed;
				if (isRecording) {
					lastAction.movement = movement;
					Debug.LogFormat ("Recording Frame: {0}, Vector: {1} ", actionCount, lastAction.movement.ToString ());
				}
			}
			rb2d.AddForce (movement);
		}
	}

	void LateUpdate ()
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			if (!isGhost && isRecording) {
				Debug.LogFormat ("Recording Frame: {0}, Vector: {1} ", actionCount, lastAction.movement.ToString ());
				actions [actionCount] = lastAction;
				lastAction = new PlayerFrameAction ();
				// Do we need to stop recording?
				if (actionCount == actions.Length - 1) {
					StopRecording ();
				}
			}
			if (isGhost && gameObject.activeSelf && actionCount >= actions.Length) {
				// We're done with playback, reset 
				Reset ();
			}
			actionCount += 1;

			if (isUsing && null != collidingWith) {
				Debug.Log ("Using object");
				collidingWith.Use (gameObject);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		collidingWith = other.gameObject.GetComponent<UsableObjectCS>();
		if (null != collidingWith) {
			Debug.Log ("Colliding with usable object.");
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		collidingWith = null;
	}

	private void flip ()
	{
		facingRight = !facingRight;
		Vector3 currentScale = transform.localScale;
		currentScale.x *= -1;
		transform.localScale = currentScale;
	}

	private void setAnimation (string state)
	{
		if (animationState != state) {
			if (!String.IsNullOrEmpty (animationState)) {
				animator.ResetTrigger (animationState);
			}
			animator.SetTrigger (state);
			animationState = state;
		}
	}
		
}
