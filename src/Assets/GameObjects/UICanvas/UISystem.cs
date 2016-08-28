using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UISystem : MonoBehaviour
{
	public Text tooltipRegion;
	public float ttFadeTime = 2.0f;
	public int ttDuration = 5;

	public Text inlineNarrativeRegion;
	public Text cutSceneRegion;

	public static UISystem Instance;

	private bool _created;

	void Awake ()
	{
		if (!_created) {
			DontDestroyOnLoad (this);
			Instance = this;
			_created = true;
		} else {
			Debug.LogWarning ("Only a single instance of " + this.name + " should exists!");
			Destroy (gameObject);
		}
	}



	public void SetTooltip(string text) {
		if (!String.IsNullOrEmpty (text)) {
			StartCoroutine (fadeTooltip (text));
		}
	}

	private IEnumerator fadeTooltip (string text)
	{
		tooltipRegion.text = text;
		Color c = tooltipRegion.color;

		float t = 0.0f;
		while (t < 1.0) {
			t += Time.deltaTime * 1.0f / ttFadeTime;
			c.a = Mathf.SmoothStep (1.0f, 0.0f, t) * .5f;
		}
		yield return new WaitForSeconds (ttDuration);
		t = 0.0f;
		while (t < 1.0) {
			t += Time.deltaTime * 1.0f / ttFadeTime;
			c.a = Mathf.SmoothStep (1.0f, 0.0f, t) * .5f;
		}
		tooltipRegion.text = "";
	}
}
