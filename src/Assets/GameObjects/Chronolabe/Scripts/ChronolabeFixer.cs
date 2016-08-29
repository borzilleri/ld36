using UnityEngine;
using System.Collections;
using Assets.CommonScripts.Inventory;

public class ChronolabeFixer : MonoBehaviour, UsableObject
{

	public GameObject chronolabe;
	public Inventory objectInventory;
	public string triggerObjectName;

	void Start ()
	{
		objectInventory = new Inventory ();
	}

	public void UseStart (GameObject user)
	{
		if (user == null || string.IsNullOrEmpty (triggerObjectName)) {
			return;
		}

		Inventory userInventory = (Inventory)user.GetComponent<PlayerInventory> ().playerInventory;
		if (userInventory != null) {
			ObjectPickup inventoryItem = userInventory.Remove (triggerObjectName);
			if (inventoryItem == null) {
				Debug.Log ("Did not find " + triggerObjectName + " in your inventory");
				return;
			}

			if (!user.GetComponent<GhostController> ().isGhost) {
				InventoryUIController uiInventory = (InventoryUIController)Transform.FindObjectOfType<InventoryUIController> ();
				if (uiInventory != null) {
					Debug.Log ("Found InventoryUIController");
					uiInventory.RemoveFromInventoryPanel (inventoryItem);
				}
			}

			// inventoryItem.gameObject.SetActive(true);
			// inventoryItem.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
			Debug.Log ("--- objectInventory ---");
			objectInventory.Add (inventoryItem);
			objectInventory.LogInventory ();
		}
	}

	public void UseEnd (GameObject user)
	{
		if (objectInventory.HasItem (triggerObjectName)) {
			//TODO: if they have the sun in their inventory do this... else tell them no

			chronolabe.transform.position = transform.position;
			Vector3 pos = transform.position;
			pos.z = -9999;
			pos.y = 9999;
			transform.position = pos;
		}

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
		UISystem.Instance.NarrateInline ("Aletheia: A piece is missing, it won't work until I fix it.", 0f, 1f);
	}
}
