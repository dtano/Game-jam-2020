using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Dialogue dialogue;
    private Inventory inventory;
    public bool active = true;
    
    //public Sprite inventorySprite;
    public Sprite[] invSpr;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    void OnMouseDown(){
        if(active){
            Transform transform = GameObject.Find("Player").transform;
            StopAllCoroutines();
            StartCoroutine(AddToInventory(transform));
        }
    }

    IEnumerator AddToInventory(Transform target){
        while(Mathf.Abs(transform.position.x - target.position.x) > 1.0f){
                yield return null;
        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
       
        // Waits until the dialogue has ended before giving the item
        while(FindObjectOfType<DialogueManager>().animator.GetBool("IsOpen") == true){
            yield return null;
        }
        
        
        // 1. Loop through the inventory to find an empty slot
        for(int j = 0; j < invSpr.Length; j++){
             for(int i = 0; i < inventory.slots.Length; i++){
                if(inventory.isFull[i] == false){
                Debug.Log("New item added");
                inventory.isFull[i] = true;
                
                inventory.slots[i].GetComponent<SetSlot>().setSlot(i, invSpr[j]);

                //inventory.slots[i].GetComponent<SetSlot>().setSlot(inventorySprite);
                Debug.Log(i);
                break;
                
                
                // Add the sprite to the inventory
                
                }
            }
        }
       

        //Debug.Log("Coroutine is now finished");
        StopCoroutine(AddToInventory(target));
        
        if(gameObject.tag == "Removeable"){
            // Deactivates the hover text associated with this object
            gameObject.GetComponent<HoverOver>().hoverOver.SetActive(false);
        
            // This will cause the object to dissapear
            gameObject.SetActive(false);
        }else{
            gameObject.GetComponent<Trigger>().active = true;
            this.active = false;
        }

        // // For the desk and fish tank, we need to modify this script
        // // Deactivates the hover text associated with this object
        // gameObject.GetComponent<HoverOver>().hoverOver.SetActive(false);
        
        // // This will cause the object to dissapear
        // gameObject.SetActive(false);

    }

    
}
