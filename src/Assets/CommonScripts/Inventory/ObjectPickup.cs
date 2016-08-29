using System;
using Assets.CommonScripts.Inventory;
using UnityEngine;

public class ObjectPickup : MonoBehaviour, Pickupable, UsableObject
{
    // Add this controller to any game object that the player can pick up and hold in their inventory.  The object  
    // must have a BoxCollider2D and be marked as Triggerable.  To enable the player to pick up the item, add the
    // PlayerInventory controller (Assets/CommonScripts/Inventory/PlayerInventory.cs) to the player's controllers.

    public void Pickup(GameObject user)
    {
        Inventory inventory = (Inventory) user.GetComponent<PlayerInventory>().playerInventory;

        if (inventory == null)
        {
            return;
        }

        inventory.Add(this);
        inventory.LogInventory();
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

    public void UseEnd(GameObject user)
    {
        Pickup(user);
    }

    public void UseStart(GameObject user)
    {
    }

    public void Nearby(GameObject user)
    {
    }
}
