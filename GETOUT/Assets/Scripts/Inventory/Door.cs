using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredItemName;
    public UIInventory uiInventory;

    private void Start()
    {
        uiInventory = GameObject.FindObjectOfType<UIInventory>();
    }

    public void TryOpen()
    {
        if (uiInventory.inventory.items.Exists(item => item.name == requiredItemName))
        {
            // The player has the required item, so the door can be opened.
            // Add code to open the door here.
        }
        else
        {
            // The player doesn't have the required item.
            // You can display a message like "The door is locked" or play a sound.
        }
    }
}