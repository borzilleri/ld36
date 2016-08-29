using System;
using UnityEngine;

using System.Collections.Generic;

public class PlayerFrameAction
{
	public enum KeyState
	{
		Up,
		Down,
		Held
	}

	Dictionary<KeyCode, KeyState> keys = new Dictionary<KeyCode, KeyState> ();

	KeyState up;
	KeyState down;
	KeyState left;
	KeyState right;
	KeyState action;

	public PlayerFrameAction ()
	{
	}

	public void SetKeyStateFromInput (KeyCode key)
	{
		if (Input.GetKeyDown (key)) {
			keys.Add (key, KeyState.Down);
		} else if (Input.GetKeyUp (key)) {
			keys.Add (key, KeyState.Up);
		} else if (Input.GetKey (key)) {
			keys.Add (key, KeyState.Held);
		}
	}

	public void SetKeyState (KeyCode key, KeyState state)
	{
		keys.Add (key, state);
	}

	public bool GetKeyUp (KeyCode key)
	{
		return keys.ContainsKey (key) && keys [key] == KeyState.Up;
	}

	public bool GetKeyDown (KeyCode key)
	{
		return keys.ContainsKey (key) && keys [key] == KeyState.Down;
	}

	public bool GetKey (KeyCode key)
	{
		return keys.ContainsKey (key) && (keys [key] == KeyState.Held || keys [key] == KeyState.Down);
	}
}
