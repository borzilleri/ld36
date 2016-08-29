using System;
using UnityEngine;

public struct PlayerMovement
{
	public static PlayerMovement zero = new PlayerMovement (Vector3.zero, false);

	bool _ignoreOneWayPlatforms;

	public bool ignoreOneWayPlatforms {
		get { return _ignoreOneWayPlatforms; }
	}

	Vector3 _vector;

	public Vector3 vector {
		get { return _vector; } 
	}

	public PlayerMovement (Vector3 move, bool ignoringOneWay)
	{
		_vector = move;
		_ignoreOneWayPlatforms = ignoringOneWay;
	}
}
