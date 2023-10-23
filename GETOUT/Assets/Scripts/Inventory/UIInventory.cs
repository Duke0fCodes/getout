using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Inventory inventory;
    public Transform itemSlotParent;
    public GameObject itemSlotPrefab;

    void Start()
    {
        UpdateInventoryUI();
    }

    void UpdateInventoryUI()
    {
        foreach (Transform child in itemSlotParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemSlotParent);
            Image itemIcon = slot.GetComponent<Image>();
            itemIcon.sprite = item.icon;
        }
    }

    public void AddItemToInventory(Item item)
    {
        if (inventory.Add(item))
        {
            UpdateInventoryUI();
        }
    }

    public void RemoveItemFromInventory(Item item)
    {
        inventory.Remove(item);
        UpdateInventoryUI();
    }
}