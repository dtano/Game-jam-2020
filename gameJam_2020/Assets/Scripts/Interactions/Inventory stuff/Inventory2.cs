using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    // Start is called before the first frame update
    private const int Slots = 8;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();


    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> RemovesItem;
    public void AddItem(IInventoryItem item)
    {
        mItems.Add(item);
        item.OnPickup();

        if(ItemAdded != null)
        {   
            //Debug.Log("Item in");
            ItemAdded(this, new InventoryEventArgs(item));
        }

        
    }

    public void RemoveItem(IInventoryItem item)
    {
        mItems.Remove(item);
        item.OnDrop();

        if(RemovesItem != null)
        {   
            //Debug.Log("Item in");
            RemovesItem(this, new InventoryEventArgs(item));
        }
    }




}
