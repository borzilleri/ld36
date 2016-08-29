using System;
using UnityEngine;

public interface UsableObject
{
	void Use (GameObject user);

	void Nearby(GameObject user);
}
