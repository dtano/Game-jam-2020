using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Vector2 originalPosition;
    public IInventoryItem Item { get; set; }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
        //Debug.Log("begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {   
        GameObject.Find("Player").GetComponent<playerMovement>().stop();
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = originalPosition;
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = true;
    }
    
}
