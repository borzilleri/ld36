using System;
using UnityEngine;

public interface UsableObject
{
	void Use (GameObject user);

	string GetTooltip();

	void Nearby(GameObject user);
}
