using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UISystem : MonoBehaviour
{
	public Text tooltipRegion;
	public float tooltipFadeTime = 2.0f;
	public int tooltipDuration = 5;

	public Text inlineNarrativeRegion;

	public Text cutSceneRegion;
	public GameObject cutSceneBackground;

	private bool cutSceneDisplaying = false;

	public static UISystem Instance;

	private bool _created;

	private string inlineNarration = "";
	private bool narratingInline = false;

	void Awake ()
	{
		if (!_created) {
			//DontDestroyOnLoad (this);
			Instance = this;
			_created = true;
		} else {
			Debug.LogWarning ("Only a single instance of " + this.name + " should exists!");
			Destroy (gameObject);
		}
	}

	public void NarrateInline (string text, float charDelay, float waitTime)
	{
		StartCoroutine (animateInlineNarration (text, charDelay, waitTime));
	}

	public void DisplayCutScene (string text, float charDelay, float waitTime)
	{
		if (narratingInline) {
			inlineNarrativeRegion.gameObject.SetActive (false);
			StopCoroutine ("animateText");
		}
		if (!cutSceneDisplaying) {
			StartCoroutine (animateCutScene (text, charDelay, waitTime));
		}
	}

	public bool CutSceneDisplaying ()
	{
		return cutSceneDisplaying;
	}

	public void SetTooltip (string text)
	{
		if (!String.IsNullOrEmpty (text)) {
			StartCoroutine (fadeTooltip (text));
		}
	}


	public IEnumerator animateInlineNarration(string text, float charDelay, float waitTime) {
		if (!String.Equals (text, inlineNarration)) {
			if (narratingInline) {
				StopCoroutine ("animateText");
				inlineNarrativeRegion.text = "";
			}
			narratingInline = true;
			inlineNarration = text;
			inlineNarrativeRegion.gameObject.SetActive (true);
			yield return StartCoroutine (animateText (inlineNarrativeRegion, text, charDelay, waitTime));
			narratingInline = false;
			inlineNarration = "";
		}
	}


	public IEnumerator animateCutScene(string text, float charDelay, float waitTime) {
		cutSceneDisplaying = true;
		cutSceneBackground.SetActive (true);
		yield return StartCoroutine (animateText (cutSceneRegion, text, charDelay, waitTime));
		cutSceneBackground.SetActive (false);
		cutSceneDisplaying = false;
	}

	IEnumerator animateText (Text region, string text, float charDelay, float postDelay)
	{
		region.text = "";
		foreach (char c in text) {
			region.text += c;
			yield return new WaitForSeconds (charDelay);
		}
		yield return new WaitForSeconds (postDelay);
		region.text = "";
	}

	IEnumerator fadeTooltip (string text)
	{
		tooltipRegion.text = text;
		Color c = tooltipRegion.color;

		easeTT (c, 0.0f, 1.0f);
		yield return new WaitForSeconds (tooltipDuration);
		easeTT (c, 1.0f, 0.0f);

		tooltipRegion.text = "";
	}

	private IEnumerator easeTT (Color ttColor, float start, float end)
	{
		float t = 0.0f;
		while (t < tooltipFadeTime) {
			t += Time.deltaTime;
			float perc = Math.Min (tooltipFadeTime, t) / tooltipFadeTime;
			float lerp = Mathf.Lerp (start, end, perc);
			Debug.Log (lerp);
			ttColor.a = lerp;
			yield return new WaitForSeconds (0.1f);
		}
	}
}
