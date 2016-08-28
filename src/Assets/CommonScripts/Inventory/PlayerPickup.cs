using UnityEngine;using System.Collections.Generic;public class PlayerPickup : MonoBehaviour {    public Dictionary<string, Pickupable> playerInventory;    bool canPickup = false;    Pickupable pickupable;    // Use this for initialization    void Start ()
    {        playerInventory = new Dictionary<string, Pickupable>();    }    void Update ()
    {
        if (canPickup && Input.GetButton("Action"))
        {
            Debug.Log("Picking up " + pickupable);

            pickupable.Pickup(gameObject);
            canPickup = false; // Set so that we only try to pickup once
        }
    }	    void OnTriggerEnter2D(Collider2D collider)    {        pickupable = (Pickupable) collider.GetComponent(typeof(Pickupable));        if (pickupable == null)        {            return;        }        canPickup = true;      }    void OnTriggerExit2D(Collider2D collider)
    {
        if ((Pickupable)collider.GetComponent(typeof(Pickupable)) == pickupable)
        {
            canPickup = false;
            pickupable = null;
        }
    }}