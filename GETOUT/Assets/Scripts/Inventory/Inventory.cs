using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int space = 10;

    public bool Add(Item item)
    {
        if (items.Count < space)
        {
            items.Add(item);
            return true;
        }
        else
        {
            Debug.Log("Inventory is full.");
            return false;
        }
    }

    public void Remove(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }
}
