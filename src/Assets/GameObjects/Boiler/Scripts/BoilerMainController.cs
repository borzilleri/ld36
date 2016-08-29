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

	void LateUpdate () 
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