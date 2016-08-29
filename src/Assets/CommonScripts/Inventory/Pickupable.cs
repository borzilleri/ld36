using UnityEngine;

// Implement this on a controller for an object to enable it to be picked up by a player. See 
// ObjectPickup.cs (Assets/CommonScripts/Inventory/ObjectPickup.cs) for an example.
public interface Pickupable : UsableObject
{    void Pickup(GameObject player);}