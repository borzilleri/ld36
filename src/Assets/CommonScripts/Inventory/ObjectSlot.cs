using Assets.CommonScripts.Inventory;
using UnityEngine;

// Add this controller to an object to have it remove an item from the player's inventory and add it back into 
// the game world.  Inventory items must have the ObjectPickup controller.  
//
// The specific item that this will remove from the player's inventory is psecified by the triggerObjectName public field.
public class ObjectSlot : MonoBehaviour, UsableObject {

    public Inventory objectInventory;
    public string triggerObjectName;

    void Start()
    {
        objectInventory = new Inventory();
    }

    public void Nearby(GameObject user)
    {
    }

	public void UseEnd(GameObject user) {
	}

    public void UseStart(GameObject user)
    {
        if (user == null || string.IsNullOrEmpty(triggerObjectName))
        {
            return;
        }

        Inventory userInventory = (Inventory)user.GetComponent<PlayerInventory>().playerInventory;
        if (userInventory != null)
        {
            ObjectPickup inventoryItem = userInventory.Remove(triggerObjectName);
            if (inventoryItem == null)
            {
                Debug.Log("Did not find " + triggerObjectName + " in your inventory");
                return;
            }

            if (!user.GetComponent<GhostController>().isGhost)
            {
                InventoryUIController uiInventory = (InventoryUIController)Transform.FindObjectOfType<InventoryUIController>();
                if (uiInventory != null)
                {
                    Debug.Log("Found InventoryUIController");
                    uiInventory.RemoveFromInventoryPanel(inventoryItem);
                }
            }

            // inventoryItem.gameObject.SetActive(true);
            // inventoryItem.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
            Debug.Log("--- objectInventory ---");
            objectInventory.Add(inventoryItem);
            objectInventory.LogInventory();
        }
    }
}
