﻿using Assets.CommonScripts.Inventory;using UnityEngine;public class ObjectSlot : MonoBehaviour, UsableObject {    public string triggerObjectName;    bool isHandled = false;    public string GetTooltip()    {        return string.Format("This object is looking for {0}", triggerObjectName);    }    public void Nearby(GameObject user)    {    }    public void Use(GameObject user)    {        if (isHandled == true || user == null || string.IsNullOrEmpty(triggerObjectName))        {            return;        }        PlayerInventory userInventory = (PlayerInventory)user.GetComponent<PlayerPickup>().playerInventory;        if (userInventory != null)        {            ObjectPickup inventoryItem = userInventory.Remove(triggerObjectName);            if (inventoryItem == null)            {                Debug.Log("Did not find " + triggerObjectName + " in your inventory");                return;            }            Debug.Log("Found " + triggerObjectName + " in your inventory");            isHandled = true;

            // Drop the object on the target
            InventoryUIController uiInventory = (InventoryUIController)Transform.FindObjectOfType<InventoryUIController>();
            if (uiInventory != null)
            {
                Debug.Log("Found InventoryUIController");
                uiInventory.RemoveFromInventoryPanel(inventoryItem, transform);
            }            inventoryItem.gameObject.SetActive(true);            inventoryItem.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);        }    }}