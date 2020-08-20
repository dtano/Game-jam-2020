﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Dialogue dialogue;
    private Inventory inventory;
    //public GameObject Item;
    public Sprite inventorySprite;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    void OnMouseDown(){
            Transform transform = GameObject.Find("Player").transform;
            StopAllCoroutines();
            StartCoroutine(AddToInventory(transform));
    }

    IEnumerator AddToInventory(Transform target){
        while(Mathf.Abs(transform.position.x - target.position.x) > 1.0f){
                yield return null;
        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        Debug.Log("Dialogue started");

        // Add the item to the inventory here
        Debug.Log("Item added to inventory");
        // 1. Loop through the inventory to find an empty slot

        // 2. Then somehow assign the inventorySprite to the slot's ItemImage

        // 3. Once that is done, PickUp must be deactivated and the normal trigger is activated

        Debug.Log("Coroutine is now finished");
        StopCoroutine(AddToInventory(target));
        
        // This will cause the object to dissapear
        // For the desk and fish tank, we need to modify this script
        gameObject.SetActive(false);

    }

    
}
