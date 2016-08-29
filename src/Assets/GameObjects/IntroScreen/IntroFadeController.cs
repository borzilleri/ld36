using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroFadeController : MonoBehaviour {

	private const float maxAlpha = 0.8f;
	private const float minAlpha = 0.6f;

	private Image img;
	private float currentFade;
	private float targetFade = minAlpha;
	private float speed = 0.002f;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();
		currentFade = img.color.a;
		Debug.Log (currentFade);
	}
	
	// Update is called once per frame
	void Update () {
		if ((speed > 0 && currentFade > targetFade) || (speed < 0 && currentFade < targetFade)) {
			speed = -speed;
			targetFade = speed > 0 ? maxAlpha : minAlpha;
		}
		currentFade += speed;
		Color currentColor = img.color;
		currentColor.a = currentFade;
		img.color = currentColor;
	}
}
