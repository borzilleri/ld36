using UnityEngine;
using System.Collections;

public class BoilerPipeController : MonoBehaviour {

	public BoilerMainController boiler;

	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	public void OnTriggerEnter2D (Collider2D user)
	{
		animator.SetBool ("Fixed", true);
		boiler.pipe = true;
	}

	public void OnTriggerExit2D (Collider2D user)
	{
		animator.SetBool ("Fixed", false);
		boiler.pipe = false;
	}

}
