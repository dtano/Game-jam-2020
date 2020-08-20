using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Vector2 originalPosition;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
        //Debug.Log("begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = originalPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
