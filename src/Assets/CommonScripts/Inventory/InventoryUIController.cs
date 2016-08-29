using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour {

    public GameObject inventoryPanelPrefab;
    public Image imagePrefab;

    private GameObject activeInventoryPanel;

    private static bool isInitialized = false;

	// Use this for initialization
	void Start () {
        if (isInitialized)
        {
            return;
        }
        
        isInitialized = true;

        activeInventoryPanel = Instantiate(inventoryPanelPrefab);
        activeInventoryPanel.transform.SetParent(gameObject.transform, false);
        activeInventoryPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
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

        inventoryItemImage.transform.SetParent(activeInventoryPanel.transform, false);
    }

    public void RemoveFromInventoryPanel(ObjectPickup inventoryItem, Transform slot)
    {
        SpriteRenderer itemSprite = inventoryItem.GetComponent<SpriteRenderer>();
        SpriteRenderer[] spritesInInventory = activeInventoryPanel.GetComponentsInChildren<SpriteRenderer>();
        foreach(var item in spritesInInventory)
        {
            Debug.Log("Found " + item.name + " in inventory");

            if (itemSprite.name == item.name)
            {
                Debug.Log("Match detected with " + itemSprite);
            }
        }

        //ObjectPickup[] itemsInInventory = activeInventoryPanel.GetComponentsInChildren<ObjectPickup>(true);

        if (spritesInInventory.Length == 0)
        {
            activeInventoryPanel.SetActive(false);
        }
    }
}
