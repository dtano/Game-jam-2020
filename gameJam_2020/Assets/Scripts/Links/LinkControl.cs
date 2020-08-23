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
    Button[] selectedItems;
    
    // Object that holds all the links
    public LinkStore linkStorage;

    // The dialogue to be played at the start and the end
    public Dialogue opening;
    public Dialogue closing;

    // The dialogue to be played when a failed link has been made
    public Dialogue[] failedStatements;

    private bool levelStart = true;
    private bool levelCleared = false;
    private bool finalDialogueCleared = false;

    // The list of links acquired from the linkStorage
    private List<LinkArray> links;
    
    // List of already linked objects
    private List<Button> linkedObjects;
    
    // Random for getting random error statements
    private System.Random rnd = new System.Random();
    
    // Which link the firstItem belongs to
    private int linkIndex;
    public DialogueManager dialogueManager;
    
    void Start()
    {
        links = linkStorage.GetLinks();
        linkedObjects = new List<Button>();

        // Disables the descriptions of the objects in the next game at the start of the level
        GameObject[] nextPageDesc = GameObject.FindGameObjectsWithTag("Additional Desc");
        for(int i = 0; i < nextPageDesc.Length; i++){
            nextPageDesc[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(levelStart){
            StopAllCoroutines();
            StartCoroutine(playDialogue(opening));
            levelStart = false;
        }

        if(finalDialogueCleared && !levelCleared){
            // Level cleared
            StopAllCoroutines();
            StartCoroutine(playDialogue(closing));
            levelCleared = true;
            // Transition out of this level
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
            // True link
            if(links.ElementAt(linkIndex).find(item)){
                if(selectedItems.Length == 1){
                    selectedItems[0] = item;
                    // Play dialogue
                    success();
                    Debug.Log("reset");
                    return true;
                }else{
                    for(int i = 0; i < selectedItems.Length; i++){
                        if(i == selectedItems.Length - 1){
                            selectedItems[i] = item;
                            success();
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

                // Get random failed message
                failed();
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

    }

    // Resets the first object and selected objects
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

        // if(links.Count - 1 == 0  && dialogueManager.animator.GetBool("IsOpen") == false){
        //     finalDialogueCleared = true;
        // }

        if(links.Count == 0 && dialogueManager.animator.GetBool("IsOpen") == false){
            finalDialogueCleared = true;
        }

        StopCoroutine(playDialogue(dialogue));

    }

    // Adding linked objects to the list and changing their tags
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

    void success(){
        addToLinkedObjects();
        StopAllCoroutines();
        StartCoroutine(playDialogue(links[linkIndex].dialogue));
        links.Remove(links[linkIndex]);

        // if(links.Count == 0 && finalDialogueCleared){
        //     levelCleared = true;
        // }

        disable();
    }

    void failed(){
         // Get random failed message
        int errorIndex = rnd.Next(failedStatements.Length);
        StopAllCoroutines();
        StartCoroutine(playDialogue(failedStatements[errorIndex]));
        reset();
    }

    

    
}
