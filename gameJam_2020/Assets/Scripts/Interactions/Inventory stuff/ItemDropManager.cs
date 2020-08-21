using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropManager : MonoBehaviour, IDropHandler
{
    public Inventory2 inventory;
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invbg = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invbg, Input.mousePosition))
        {
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragManager>().Item;
            
            if(item != null)
            {
                Debug.Log("out");
                inventory.RemoveItem(item);
                item.OnDrop();
            }
            
        }
        
    }
}
