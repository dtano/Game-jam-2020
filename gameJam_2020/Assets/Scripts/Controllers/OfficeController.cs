﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeController : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    private GameObject tutorialMessage;
    
    private DialogueManager dialogueManager;
    public Dialogue openingDialogue;
    public Dialogue closingDialogue;

    private bool levelStart = true;
    private bool levelCleared = false;
    private bool tutorialCleared = false;


    Transform interactableObjects;
    GameObject hover;
    
    // Start is called before the first frame update
    void Start()
    {
        // Player can't move when the level starts
        player.GetComponent<playerMovement>().enabled = false;
        dialogueManager = FindObjectOfType<DialogueManager>();

        
        // The list of interactable objects
        interactableObjects = GameObject.Find("Interactable Objects").transform;
        
        // All hover texts except letter
        hover = GameObject.Find("HoverText");

        tutorialMessage = GameObject.Find("TutorialMessage");
        tutorialMessage.SetActive(false);
        
        // Deactivates every interaction and hovers, except letter 
        deactivateTriggers();
        

        

    }

    // Update is called once per frame
    void Update()
    {
        // Opens the level with some dialogue
        if(levelStart){
            dialogueManager.StartDialogue(openingDialogue);
            //tutorialMessage.SetActive(true);
            levelStart = false;
        }

        if(!tutorialCleared && dialogueManager.animator.GetBool("IsOpen") == false){
            tutorialMessage.SetActive(true);
        }

        // Check to see whether or not the player has picked the letter up
        if(player.GetComponent<Inventory>().isFull[0] && !tutorialCleared){
            // Activate every trigger and pickup of every other object
            tutorialMessage.SetActive(false);
            activateTriggers();
            tutorialCleared = true;
        }

        // When the player has picked everything up
        if(player.GetComponent<Inventory>().full() && !levelCleared){
            player.GetComponent<playerMovement>().enabled = false;
            door.GetComponent<Trigger>().active = false;
            // Activates the door's playerTransfer script?

            dialogueManager.StartDialogue(closingDialogue);
            door.GetComponent<PlayerTransfer>().active = true;
            levelCleared = true;
        }

        

        
    }

    // Activates every hover text and trigger
    void activateTriggers(){
        hover.SetActive(true);
        foreach (Transform ob in interactableObjects.transform){
            

            if(ob.tag == "Interactable"){
                ob.GetComponent<Trigger>().active = true;
            }else if(ob.tag == "Removeable" || ob.tag == "Item Adder"){
                ob.GetComponent<PickUp>().active = true;
            }else if(ob.tag == "Item Adder"){
                ob.GetComponent<PickUp>().active = true;
            }
        }

    }

    // Deactivates every hover text and trigger
    void deactivateTriggers(){
        hover.SetActive(false);
        foreach (Transform ob in interactableObjects.transform){

            if(ob.name != "Letter_face_up"){
                if(ob.tag == "Interactable"){
                    ob.GetComponent<Trigger>().active = false;
                }else if(ob.tag == "Removeable"){
                    ob.GetComponent<PickUp>().active = false;
                }else if(ob.tag == "Item Adder"){
                    ob.GetComponent<PickUp>().active = false;
                    ob.GetComponent<Trigger>().active = false;
                }
            }

            
        }
    }
}
