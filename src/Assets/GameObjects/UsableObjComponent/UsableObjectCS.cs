using UnityEngine;
using System.Collections;

public class UsableObjectCS : MonoBehaviour {
	private ParticleSystem particles;
	private UsableObject target;

	void Start() {
		target = GetComponentInParent(typeof(UsableObject)) as UsableObject;
		particles = GetComponent<ParticleSystem> ();
	}
		
	public void OnTriggerEnter2D(Collider2D other) {
		if (null != particles) {
			ParticleSystem.EmissionModule emit = particles.emission;
			emit.enabled = true;
		}
	}

	public void OnTriggerExit2D(Collider2D other) {
		if (null != particles) {
			ParticleSystem.EmissionModule emit = particles.emission;
			emit.enabled = false;
		}
	}

	public void Use(GameObject user) {
		target.Use (user);
	}
}
