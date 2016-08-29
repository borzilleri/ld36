using UnityEngine;
using System.Collections;

public class BoilerPipeController : MonoBehaviour {

	public BoilerMainController boiler;
	private bool triggered = false;
	private Collider2D other;

	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	void Update()
	{
		if (triggered && (null == other || !other.isActiveAndEnabled)) {
			animator.SetBool ("Fixed", false);
			boiler.pipe = false;
			triggered = false;
		}
	}

	public void OnTriggerEnter2D (Collider2D user)
	{
		animator.SetBool ("Fixed", true);
		boiler.pipe = true;
		triggered = true;
		other = user;
	}

	public void OnTriggerExit2D (Collider2D user)
	{
		animator.SetBool ("Fixed", false);
		boiler.pipe = false;
		triggered = false;
	}

}
