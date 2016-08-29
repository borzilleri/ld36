using Assets.CommonScripts.Inventory;
using UnityEngine;

public class ObjectPickup : MonoBehaviour, Pickupable {

    // Add this controller to any game object that the player can pick up and hold in their inventory.  To enable
    // the player to pick up the item, add the PlayerPickup controller (Assets/CommonScripts/Inventory/PlayerPickup.cs)
    // to the player's controllers.

    public void Pickup(GameObject user)
    {
        PlayerInventory inventory = (PlayerInventory) user.GetComponent<PlayerPickup>().playerInventory;

        if (inventory == null)
        {
            return;
        }

        inventory.Add(this);
        inventory.LogInventory();

        Debug.Log("Hiding " + gameObject);
        this.gameObject.SetActive(false);

        if (!user.GetComponent<GhostController>().isGhost)
        {
            InventoryUIController uiInventory = (InventoryUIController)Transform.FindObjectOfType<InventoryUIController>();
            if (uiInventory == null)
            {
                Debug.Log("Couldn't find InventoryUIController");
                return;
            }
            uiInventory.AddToInventoryPanel(this);
        }
    }
}
