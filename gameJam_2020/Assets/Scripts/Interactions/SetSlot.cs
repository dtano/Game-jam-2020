﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSlot : MonoBehaviour
{   
    public Sprite inventorySprite;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void setSlot(int slotNum,Sprite inventorySprite){
        Image slotImage = transform.GetChild(0).GetComponent<Image>();
        slotImage.enabled = true;
        slotImage.sprite = inventorySprite;

        GameObject.Find("Player").GetComponent<Inventory>().isFull[slotNum] = true;
    }

    
}
