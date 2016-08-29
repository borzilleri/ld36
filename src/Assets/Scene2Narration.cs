using UnityEngine;
using System.Collections;

public class Scene2Narration : MonoBehaviour
{
	public void UseStart (GameObject user)
	{

	}

	public void UseEnd (GameObject user)
	{
	}

	bool _narrationTriggered = false;
	string narration = @"Emerging from the warehouse, Aletheia looks around at her village. The buildings are in ruin and the landscape is unrecognizable. Stepping on a trigger plate, Aletheia summons the chronolabe to check the date. The gears spin rapidly to catch up, and even then it takes a long time for the planets to arrive at the present date. Aletheia realizes that several centuries have passed, something that could only be possible if a chronosphere was smashed.

Aletheia recalls hearing that it would be possible to travel back in time with a chronolabe. Such knowledge was forbidden to citizens such as her, but would be accessible to scholars at the local Musaeum. She only hopes that the scrolls she needs are intact enough to read.";

	public void Nearby (GameObject user)
	{
		if (!_narrationTriggered) {
			UISystem.Instance.DisplayCutScene (narration, 0.1f, 3f);
			_narrationTriggered = true;
		}
	}
}
