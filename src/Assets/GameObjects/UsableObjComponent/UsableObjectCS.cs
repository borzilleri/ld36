using UnityEngine;
using System.Collections;

/**
 * Using this component:
 * 
 * 1. Implement the UsableObject interface (Assets/CommonScripts/UsableObject) on a script component of your game object.
 * 2. Add the UsableObjectTpl Prefab as a child of your game object.
 * 3. Adjust Position of Transform, Radius/Offset of Circile Collider, and Radius of Emission Shape as needed.
 */
public class UsableObjectCS : MonoBehaviour
{
	private ParticleSystem particles;
	private UsableObject target;

	void Start ()
	{
		target = GetComponentInParent (typeof(UsableObject)) as UsableObject;
		particles = GetComponent<ParticleSystem> ();
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (null != particles) {
			particles.Play ();
		}
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			if (null != other.GetComponents<PlayerController> ()) {
				target.Nearby (other.gameObject);
			}
		}
		UISystem.Instance.SetTooltip (target.GetTooltip ());
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		if (null != particles) {
			particles.Stop ();
		}
	}

	public void Use (GameObject user)
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			target.Use (user);
		}
	}
}
