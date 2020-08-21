using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeController : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    public Dialogue dialogue;

    private bool levelStart = true;
    private bool levelCleared = false;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<playerMovement>().enabled = false;
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    // Update is called once per frame
    void Update()
    {
        if(levelStart){
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            levelStart = false;
        }

        if(player.GetComponent<Inventory>().full()){
            player.GetComponent<playerMovement>().enabled = false;
            // Activates the door's playerTransfer script?
            Debug.Log("Every item has been taken");
            levelCleared = true;
        }

        
    }
}
