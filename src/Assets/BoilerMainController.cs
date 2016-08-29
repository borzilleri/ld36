using UnityEngine;
using System.Collections;

public class BoilerMainController : MonoBehaviour {

	public SpriteRenderer smokeRender;
	public SpriteRenderer fireRender;
	public SpriteRenderer waterRender;
	public SpriteRenderer steamRender;
	public HiddenTempleDoorController exitDoor;

	public bool pipe = false;
	public bool fire = false;
	public bool water = false;

	private bool lastDoorState = false;

	void Update () 
	{
		fireRender.enabled = fire;
		waterRender.enabled = water;
		smokeRender.enabled = !pipe && !water && fire;
		steamRender.enabled = !pipe && fire && water;
		bool doorState = fire && water && pipe;
		if(doorState != lastDoorState) {
			exitDoor.setDoorOpen (fire && water && pipe);
			lastDoorState = doorState;
		}
	}
}



/*
 * 
 * 

		openPosition = new Vector3 (transform.position.x, transform.position.y + openOffset, 0);
		closePosition = transform.position;	
		spriteRenderer = GetComponent<SpriteRenderer> ();

	public int openOffset;
	private Vector3 openPosition;
	private Vector3 closePosition;

	//Pulled code from the door controller to get a water falling effect
//totally not perfect but nothing is
private bool isClosed = false;
private float fraction = 0;
private int speed = 5;
private SpriteRenderer spriteRenderer;


		if (isClosed && fraction < 1) {
			fraction += Time.deltaTime * speed;
		} else if(!isClosed && fraction > 0) {
			fraction -= Time.deltaTime * speed;
		}
		transform.position = Vector3.Lerp (openPosition, closePosition, fraction);
*/