using System;
using UnityEngine;

public interface UsableObject
{
	void UseStart (GameObject user);

	void UseEnd (GameObject user);

	void Nearby (GameObject user);
}
