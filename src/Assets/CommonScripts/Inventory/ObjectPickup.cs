using Assets.CommonScripts.Inventory;
using UnityEngine;

public class ObjectPickup : MonoBehaviour, Pickupable {

    public void Pickup(GameObject player)
    {
        PlayerInventory inventory = (PlayerInventory) player.GetComponent<PlayerPickup>().playerInventory;

        if (inventory == null)
        {
            return;
        }

        inventory.Add(this);
        inventory.LogInventory();

        Debug.Log("Hiding " + gameObject);
        this.gameObject.SetActive(false);

        InventoryUIController uiInventory = (InventoryUIController)Transform.FindObjectOfType<InventoryUIController>();
        if (uiInventory == null)
        {
            Debug.Log("Couldn't find InventoryUIController");
            return;
        }
        uiInventory.AddToInventoryPanel(this);
    }
}
