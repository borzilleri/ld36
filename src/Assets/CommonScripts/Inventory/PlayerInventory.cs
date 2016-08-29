using System;
using Assets.CommonScripts.Inventory;using UnityEngine;

// Add this controller to a player to enable them to pick up items in the game world.  The item must have a controller
// which implements the Pickupable interface (Assets/CommonScripts/Inventory/Pickupable.cs) such as ObjectPickup.cs.
public class PlayerInventory : MonoBehaviour{    public Inventory playerInventory;    void Start()    {        playerInventory = new Inventory();    }
}