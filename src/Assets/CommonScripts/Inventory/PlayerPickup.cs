﻿using UnityEngine;
    {
    {
        if (canPickup && Input.GetButton("Action"))
        {
            Debug.Log("Picking up " + pickupable);

            pickupable.Pickup(gameObject);
            canPickup = false; // Set so that we only try to pickup once
        }
    }
    {
        if ((Pickupable)collider.GetComponent(typeof(Pickupable)) == pickupable)
        {
            canPickup = false;
            pickupable = null;
        }
    }