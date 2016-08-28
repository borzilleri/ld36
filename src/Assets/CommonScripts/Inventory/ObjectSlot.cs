using UnityEngine;using System.Collections.Generic;

public class ObjectSlot : MonoBehaviour, UsableObject {    public string triggerObjectName;

    bool isHandled = false;

    public string GetTooltip()
    {
        return string.Format("This object is looking for {0}", triggerObjectName);
    }

    public void Use(GameObject user)    {        if (isHandled == true || user == null || string.IsNullOrEmpty(triggerObjectName))        {            return;        }        Dictionary<string, Pickupable> userInventory = (Dictionary<string, Pickupable>)user.GetComponent<PlayerPickup>().playerInventory;        if (userInventory != null)        {
            Pickupable inventoryItem;
            if (!userInventory.TryGetValue(triggerObjectName, out inventoryItem))
            {
                Debug.Log("Did not find " + triggerObjectName + " in your inventory");
                return;
            }

            if (inventoryItem.GetType() != typeof(ObjectPickup))
            {
                Debug.Log("Did not find a " + triggerObjectName + " of the right base type in your inventory");
                return;
            }

            Debug.Log("Found " + triggerObjectName + " in your inventory");
            userInventory.Remove(triggerObjectName);
            isHandled = true;

            Debug.Log("Removed " + triggerObjectName + " from your inventory.");

            // Drop the object on the ground
            ((ObjectPickup)inventoryItem).gameObject.SetActive(true);
            ((ObjectPickup)inventoryItem).transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
        }    }}