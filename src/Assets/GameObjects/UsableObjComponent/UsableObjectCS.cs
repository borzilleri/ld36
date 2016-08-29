using UnityEngine;
using System.Collections;

/**
 * Using this component:
 * 
 * 1. Add This Prefab as a child of the object you want to use (or, honestly anywhere in your game object heirarchy).
 * 2. Assign the target to the object you want to trigger UseStart/UseEnd/Nearby on. Ensure that object has a script 
 *    attached which implements the UsableObject Interface
 * 3. Assign the trigger to the object with a SpriteRenderer that you want the user to interact with.
 * 4. Edit the usableRadiusPercent to change the X-radius (distance from center) of the trigger area.
 * 5. Adjust the offset of the BoxCollider2D if needed.
 */
[RequireComponent (typeof(BoxCollider2D))]
public class UsableObjectCS : MonoBehaviour
{
	public GameObject target;
	public GameObject trigger;

	public float usableRadiusPercent = 1.25f;
	private ParticleSystem particles;

	void Start ()
	{
		particles = GetComponent<ParticleSystem> ();
		SpriteRenderer sprite = trigger.GetComponent<SpriteRenderer> ();

		ParticleSystem.ShapeModule shape = particles.shape;
		shape.radius = sprite.bounds.extents.x * 0.8f;

		Vector2 triggerSize = sprite.bounds.size;
		triggerSize.x *= usableRadiusPercent;

		GetComponent<BoxCollider2D> ().size = triggerSize;
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
