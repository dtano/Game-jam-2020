using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Dialogue dialogue;
    private Inventory inventory;
    
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
        //Debug.Log("Dialogue started");

        // Add the item to the inventory here
        //Debug.Log("Item added to inventory");
        
        // 1. Loop through the inventory to find an empty slot
        for(int i = 0; i < inventory.slots.Length; i++){
            if(inventory.isFull[i] == false){
                Debug.Log("New item added");
                inventory.isFull[i] = true;
                //inventory.slots[i].GetComponent<SetSlot>().enabled = true;
                //inventory.slots[i].GetComponent<SetSlot>().inventorySprite = inventorySprite;

                inventory.slots[i].GetComponent<SetSlot>().setSlot(inventorySprite);
                Debug.Log(i);
                break;
                
                
                // Add the sprite to the inventory
                
            }
        }
        // 2. Then somehow assign the inventorySprite to the slot's ItemImage

        // 3. Once that is done, PickUp must be deactivated and the normal trigger is activated

        //Debug.Log("Coroutine is now finished");
        StopCoroutine(AddToInventory(target));
        
        
        // For the desk and fish tank, we need to modify this script
        // Deactivates the hover text associated with this object
        gameObject.GetComponent<HoverOver>().hoverOver.SetActive(false);
        
        // This will cause the object to dissapear
        gameObject.SetActive(false);

    }

    
}
