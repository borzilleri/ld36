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
	public GameObject target;
	private ParticleSystem particles;

	void Start ()
	{
		particles = GetComponent<ParticleSystem> ();

		Bounds spriteBounds = GetComponentInParent<SpriteRenderer> ().bounds;
		ParticleSystem.ShapeModule shape = particles.shape;
		shape.radius = spriteBounds.extents.x * 0.8f;

		GetComponent<BoxCollider2D> ().size = spriteBounds.size;
		GetComponent<BoxCollider2D> ().offset = new Vector2 (spriteBounds.extents.x, 0);
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (null != particles) {
			particles.Play ();
		}
		if (!UISystem.Instance.CutSceneDisplaying ()) {
			if (null != other.GetComponents<PlayerController> ()) {
				target.SendMessage ("Nearby", other);
			}
		}
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
			target.SendMessage ("Use", user);
		}
	}
}
