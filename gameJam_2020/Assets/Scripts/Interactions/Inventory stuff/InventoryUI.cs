using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public Inventory2 Inventory;

    // Start is called before the first frame update
    void Start()
    {
        
        Inventory.ItemAdded += Inventory2Script_ItemAdded;
        //Inventory.RemovesItem += Inventory2Script_RemovesItem;
    }

    
    private void Inventory2Script_ItemAdded(object sender, InventoryEventArgs e)
    {   
        
        Transform inventoryPanel = transform.Find("Slots");
        //Debug.Log("Item in");
        foreach(Transform slot in inventoryPanel){

            Transform imageTransform = slot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragManager itemDragManager = imageTransform.GetComponent<ItemDragManager>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                itemDragManager.Item = e.Item;
                break;
            }

            

            
        }
        
        /*
        Image image = transform.GetChild(0).GetComponent<Image>();
        image.enabled = true;
        image.sprite = e.Item.Image;
        */
    }

    
    private void Inventory2Script_RemovesItem(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Slots");
        foreach(Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragManager itemDragManager = imageTransform.GetComponent<ItemDragManager>();
            
            if(itemDragManager.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragManager.Item = null;
                break;
            }
            
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
