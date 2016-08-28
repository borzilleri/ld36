using System.Collections.Generic;
using UnityEngine;public class ObjectPickup : MonoBehaviour, Pickupable {
    public void Pickup(GameObject player)    {        Dictionary<string, Pickupable> inventory = (Dictionary<string, Pickupable>) player.GetComponent<PlayerPickup>().playerInventory;        if (inventory == null)        {            return;        }        inventory.Add(gameObject.name, this);        foreach (var item in inventory)        {            Debug.Log("Inventory has " + item.Key);        }        Debug.Log("Hiding " + gameObject);
        this.gameObject.SetActive(false);
    }
}