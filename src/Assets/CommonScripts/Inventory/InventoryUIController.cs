using UnityEngine;

public class InventoryUIController : MonoBehaviour {

    public GameObject inventoryPanelPrefab;
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
        //inventoryPanel.SetActive(false);
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

        inventoryItem.transform.SetParent(activeInventoryPanel.transform);
    }

    public void RemoveFromInventoryPanel(ObjectPickup inventoryItem, Transform slot)
    {
        inventoryItem.transform.SetParent(slot);

        ObjectPickup[] itemsInInventory = activeInventoryPanel.GetComponentsInChildren<ObjectPickup>(true);

        if (itemsInInventory.Length == 0)
        {
            activeInventoryPanel.SetActive(false);
        }
    }
}
