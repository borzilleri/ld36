﻿using Assets.CommonScripts.Inventory;
using UnityEngine;
using UnityEngine.UI;

// Add to the Canvas and assign the InventoryPanel and Image prefabs
public class InventoryUIController : MonoBehaviour {

    public GameObject inventoryPanelPrefab;
    public Image imagePrefab;

    private GameObject activeInventoryPanel;

    private static bool isInitialized = false;

	void Start () {
        if (isInitialized) // Make sure there is only ever one of these
        {
            return;
        }
        
        isInitialized = true;

        activeInventoryPanel = Instantiate(inventoryPanelPrefab);
        activeInventoryPanel.transform.SetParent(gameObject.transform, false);
        activeInventoryPanel.SetActive(false);
	}

    public void AddToInventoryPanel(ObjectPickup inventoryItem)
    {
        if (!activeInventoryPanel.activeInHierarchy)
        {
            activeInventoryPanel.SetActive(true);
        }

        SpriteRenderer itemSpriteRenderer = inventoryItem.GetComponent<SpriteRenderer>();

        Image inventoryItemImage = Instantiate(imagePrefab);
        inventoryItemImage.sprite = itemSpriteRenderer.sprite;
        inventoryItemImage.material = itemSpriteRenderer.material;
        inventoryItemImage.color = itemSpriteRenderer.color;
        inventoryItemImage.name = itemSpriteRenderer.name;

        Debug.Log("AddToInventoryPanel : Added " + inventoryItemImage.name + " to UI inventory");

        inventoryItemImage.transform.SetParent(activeInventoryPanel.transform, false);
    }

    public void AddToInventoryPanel(ObjectPickup inventoryItem, GameObject user)
    {
        AddToInventoryPanel(inventoryItem);

        // DEBUG
        Debug.Log("--- AddToInventoryPanel ---");
        Inventory inventory = (Inventory)user.GetComponent<PlayerInventory>().playerInventory;
        inventory.LogInventory();
    }

    public void RemoveFromInventoryPanel(ObjectPickup inventoryItem)
    {
        SpriteRenderer itemSpriteRenderer = inventoryItem.GetComponent<SpriteRenderer>();
        Image[] imagesInInventory = activeInventoryPanel.GetComponentsInChildren<Image>();
        foreach(var image in imagesInInventory)
        {
            if (itemSpriteRenderer.name == image.name)
            {
                Debug.Log("Match detected with " + itemSpriteRenderer);
                DestroyObject(image);
            }
        }

        if (imagesInInventory.Length == 0)
        {
            activeInventoryPanel.SetActive(false);
        }
    }

    public void RemoveFromInventoryPanel(ObjectPickup inventoryItem, GameObject user)
    {
        RemoveFromInventoryPanel(inventoryItem);

        // DEBUG
        Debug.Log("--- RemoveFromInventoryPanel ---");
        Inventory inventory = (Inventory)user.GetComponent<PlayerInventory>().playerInventory;
        inventory.LogInventory();
    }
}
