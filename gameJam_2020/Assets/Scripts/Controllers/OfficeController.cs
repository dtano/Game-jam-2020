using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeController : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    
    private DialogueManager dialogueManager;
    public Dialogue openingDialogue;
    public Dialogue closingDialogue;

    private bool levelStart = true;
    private bool levelCleared = false;


    // Types of interactable objects
    GameObject[] interactables;
    GameObject[] removeables; 
    GameObject[] itemAdders; 
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<playerMovement>().enabled = false;
        dialogueManager = FindObjectOfType<DialogueManager>();

        interactables = GameObject.FindGameObjectsWithTag("Interactable");
        removeables = GameObject.FindGameObjectsWithTag("Removeable");
        itemAdders = GameObject.FindGameObjectsWithTag("Item Adder");
        deactivateTriggers();
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        

    }

    // Update is called once per frame
    void Update()
    {
        if(levelStart){
            dialogueManager.StartDialogue(openingDialogue);
            levelStart = false;
        }

        if(player.GetComponent<Inventory>().isFull[0]){
            // Activate every trigger and pickup of every other object
            activateTriggers();
        }

        if(player.GetComponent<Inventory>().full() && !levelCleared){
            player.GetComponent<playerMovement>().enabled = false;
            door.GetComponent<Trigger>().active = false;
            // Activates the door's playerTransfer script?

            dialogueManager.StartDialogue(closingDialogue);
            door.GetComponent<PlayerTransfer>().active = true;
            levelCleared = true;
        }

        

        
    }

    void activateTriggers(){
        foreach(GameObject ob in interactables){
            ob.GetComponent<Trigger>().active = true;
        }

        foreach(GameObject ob in removeables){
            ob.GetComponent<PickUp>().active = true;
        }

        foreach(GameObject ob in itemAdders){
            ob.GetComponent<PickUp>().active = true;
        }

    }

    void deactivateTriggers(){
        foreach(GameObject ob in interactables){
            ob.GetComponent<Trigger>().active = false;
        }

        foreach(GameObject ob in removeables){
            if(ob.name != "Letter_face_up"){
                ob.GetComponent<PickUp>().active = false;
            }
        }

        foreach(GameObject ob in itemAdders){
            ob.GetComponent<PickUp>().active = false;
        }
    }
}
