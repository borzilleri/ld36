using UnityEngine;
using System.Collections;

/**
 * Using this component:
 * 
 * 1. Implement the UsableObject interface (Assets/CommonScripts/UsableObject) on a script component of your game object.
 * 2. Add the UsableObjectTpl Prefab as a child of your game object.
 * 3. Adjust Position of Transform, Radius/Offset of Circile Collider, and Radius of Emission Shape as needed.
 */
[RequireComponent (typeof(BoxCollider2D))]
public class UsableObjectCS : MonoBehaviour
{
	public GameObject target;
	public float usableRadiusPercent = 1.25f;
	private ParticleSystem particles;

	void Start ()
	{
		particles = GetComponent<ParticleSystem> ();
		ParticleSystem.ShapeModule shape = particles.shape;

		SpriteRenderer sprite = GetComponentInParent<SpriteRenderer> ();
		shape.radius = sprite.bounds.extents.x * 0.8f;

		Vector2 colliderSize = sprite.bounds.size;
		colliderSize.x *= usableRadiusPercent;

		GetComponent<BoxCollider2D> ().size = colliderSize;
		GetComponent<BoxCollider2D> ().transform.position = sprite.transform.position;
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (null != particles) {
			particles.Play ();
		}
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			if (null != other.GetComponents<PlayerController> ()) {
				target.SendMessage ("Nearby", other.gameObject);
			}
		}
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		if (null != particles) {
			particles.Stop ();
		}
	}

	public void StopUsing (GameObject user)
	{
		target.SendMessage ("UseEnd", user);
	}

	public void StartUsing (GameObject user)
	{
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			target.SendMessage ("UseStart", user);
		}
	}
}
