using System;
using UnityEngine;

public struct PlayerFrameAction
{
	public Vector2 movement;
	public bool isUsing;

	public PlayerFrameAction(Vector2 movement, bool isUsing) {
		this.movement = movement;
		this.isUsing = isUsing;
	}
}
