using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System;

public class LinkControl : MonoBehaviour
{
    Button firstItem;
    Button secondItem;

    Button[] selectedItems;
    public LinkStore linkStorage;

    private LinkArray[] links;
    
    // Which link the firstItem belongs to
    private int linkIndex;
    // Start is called before the first frame update
    void Start()
    {
        links = linkStorage.GetLinks();
    }

    // Update is called once per frame
    void Update()
    {
        if(firstItem != null){
            //Debug.Log(firstItem);
        }

        if(secondItem != null){
            //Debug.Log(secondItem);
        }
    }

    // Attaches the button to either the firstItem or the selected items
    public bool attach(Button item){
        if(firstItem == null){
            firstItem = item;
            Debug.Log(firstItem);
            for(int i = 0; i < links.Length; i++){
                if(links[i].find(item)){
                    selectedItems = new Button[links[i].Length() - 1];
                    linkIndex = i;
                    Debug.Log("Link has been found, length of available selected items is " + selectedItems.Length);
                    return true;
                }
            }
            Debug.Log("Link somehow not found");
            reset();
        }else if(firstItem != null && selectedItems != null){
            Debug.Log("Time to check the other selected items");
            if(links[linkIndex].find(item)){
                if(selectedItems.Length == 1){
                    selectedItems[0] = item;
                    //item.interactable = false;
                    // true link
                    // Remove the items from the board
                    // Play dialogue
                    // How do we access the dialogue damn it
                    // Ah get the dialogue associated with this link, save it in the Link object
                    disable();
                    Debug.Log("reset");
                    return true;
                }else{
                    for(int i = 0; i < selectedItems.Length; i++){
                        if(i == selectedItems.Length - 1){
                            selectedItems[i] = item;
                            disable();
                            // True link
                            // Play dialogue
                            return true;

                        }
                        
                        if(selectedItems[i] == null){
                            selectedItems[i] = item;
                            return true;
                        }
                    }
                }
            }else{
                // Play failed dialogue
                //firstItem.interactable = true;
                reset();
            }
        }
        
        return false;

    }

    public void restoreLinks(GameObject page){
        if(firstItem != null && firstItem.transform.parent == page){
            firstItem.interactable = false;
        }

        if(selectedItems != null){
            for(int i = 0; i< selectedItems.Length; i++){
                if(selectedItems[i].transform.parent == page){
                    selectedItems[i].interactable = false;
                }
            }
        }

        // if(secondItem != null && secondItem.transform.parent == page){
        //     secondItem.interactable = false;
        // }
    }

    void reset(){
        firstItem.interactable = true;
        firstItem = null;
        for(int i = 0; i < selectedItems.Length; i++){
            selectedItems[i].interactable = true;
            selectedItems[i] = null;
        }
        selectedItems = null;
    }

    void disable(){
        firstItem.interactable = false;
        firstItem.GetComponent<BoxCollider2D>().enabled = false;
        firstItem = null;

        for(int i = 0; i < selectedItems.Length; i++){
            Debug.Log(selectedItems[i]);
            selectedItems[i].interactable = false;
            selectedItems[i].GetComponent<BoxCollider2D>().enabled = false;
            selectedItems[i] = null;
        }
        selectedItems = null;
    }

    
}
