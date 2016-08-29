using UnityEngine;
using System.Collections;

public class ChronolabeFixer : MonoBehaviour, UsableObject {

	public GameObject chronolabe;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UseStart (GameObject user)
	{

	}

	public void UseEnd (GameObject user)
	{
		//TODO: if they have the sun in their inventory do this... else tell them no

		chronolabe.transform.position = transform.position;
		Vector3 pos = transform.position;
		pos.z = -9999;
		pos.y = 9999;
		transform.position = pos;

		//originally I was Instantiating the prefab, but that caused problems with the resest
		//for some reason it cannot access the labe after it is dynamically added
		//so instead I started teh scene with the working chronolabe and just adjust it's transform
		//so it's not in view until it is time... I'm leaving this code incase we ant to try this again

//		GameObject newlabe = Instantiate (chronolabe);
//		newlabe.transform.position = transform.position;
//		newlabe.transform.rotation = transform.rotation;
//		Destroy (gameObject);		
	}

	public void Nearby (GameObject user)
	{
	}
}
