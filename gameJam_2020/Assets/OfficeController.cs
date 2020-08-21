using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeController : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    public Dialogue dialogue;

    private bool levelStart = true;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<playerMovement>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(levelStart){
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            levelStart = false;
        }
    }
}
