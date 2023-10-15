using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
   public enum ItemType
    {
        Knife,
        Board,
        Bat,
        Ball,
    }

    public ItemType itemType;
    public int amount;
}
