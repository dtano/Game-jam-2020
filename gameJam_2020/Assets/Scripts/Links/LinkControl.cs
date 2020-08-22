﻿using System.Collections;
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

    
    private List<LinkArray> links;
    private List<Button> linkedObjects;
    
    // Which link the firstItem belongs to
    private int linkIndex;
    // Start is called before the first frame update

    public DialogueManager dialogueManager;
    void Start()
    {
        links = linkStorage.GetLinks();
        linkedObjects = new List<Button>();
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
        // For the first selected object
        if(firstItem == null){
            firstItem = item;
            Debug.Log(firstItem);
            int index = 0;
            foreach(LinkArray link in links){
                if(link.find(item)){
                    selectedItems = new Button[link.Length() - 1];
                    linkIndex = index;
                    return true;

                }
                index++;
            }
            Debug.Log("Link somehow not found");
            reset();
        }else if(firstItem != null && selectedItems != null){
            Debug.Log("Time to check the other selected items");
            
            if(links.ElementAt(linkIndex).find(item)){
                if(selectedItems.Length == 1){
                    selectedItems[0] = item;
                    addToLinkedObjects();
                    // true link
                    // Play dialogue
                    // How do we access the dialogue damn it
                    // Ah get the dialogue associated with this link, save it in the Link object
                    StopAllCoroutines();
                    StartCoroutine(playDialogue(links[linkIndex].dialogue));
                    //dialogueManager.StartDialogue(links[linkIndex].dialogue);
                    
                    disable();
                    Debug.Log("reset");
                    return true;
                }else{
                    for(int i = 0; i < selectedItems.Length; i++){
                        if(i == selectedItems.Length - 1){
                            selectedItems[i] = item;
                            addToLinkedObjects();
                            
                            StopAllCoroutines();
                            StartCoroutine(playDialogue(links[linkIndex].dialogue));
                            
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
                if(selectedItems[i] != null && selectedItems[i].transform.parent == page){
                    selectedItems[i].interactable = false;
                }
            }
        }

        // if(secondItem != null && secondItem.transform.parent == page){
        //     secondItem.interactable = false;
        // }
    }

    // 
    void reset(){
        firstItem.interactable = true;
        firstItem = null;
        for(int i = 0; i < selectedItems.Length; i++){
            if(selectedItems[i] != null){
                selectedItems[i].interactable = true;
                selectedItems[i] = null;
            }
            // selectedItems[i].interactable = true;
            // selectedItems[i] = null;
        }
        selectedItems = null;
    }

    // Disables the true links
    void disable(){
        firstItem.interactable = false;
        firstItem.GetComponent<BoxCollider2D>().enabled = false;
        firstItem = null;

        for(int i = 0; i < selectedItems.Length; i++){
            Debug.Log(selectedItems[i]);
            if(selectedItems[i] != null){
                selectedItems[i].interactable = false;
                selectedItems[i].GetComponent<BoxCollider2D>().enabled = false;
                selectedItems[i] = null;
            }
            // selectedItems[i].interactable = false;
            // selectedItems[i].GetComponent<BoxCollider2D>().enabled = false;
            // selectedItems[i] = null;
        }
        selectedItems = null;
    }

    IEnumerator playDialogue(Dialogue dialogue){
        dialogueManager.StartDialogue(dialogue);
        GameObject.Find("Background").GetComponent<ControlButtons>().disableButtons();
        while(dialogueManager.animator.GetBool("IsOpen") == true){
            yield return null;
        }

        GameObject.Find("Background").GetComponent<ControlButtons>().activateButtons();

        StopCoroutine(playDialogue(dialogue));

    }

    void addToLinkedObjects(){
        linkedObjects.Add(firstItem);
        firstItem.transform.gameObject.tag = "Linked";

        for(int i = 0; i < selectedItems.Length; i++){
            if(selectedItems[i] != null){
                Debug.Log("Time to change tags");
                selectedItems[i].transform.gameObject.tag = "Linked";
                linkedObjects.Add(selectedItems[i]);
            }else{
                Debug.Log("No change because null");
            }
        }
    }

    
}
