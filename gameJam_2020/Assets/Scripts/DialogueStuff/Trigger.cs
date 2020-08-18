    using UnityEngine;
    using System.Collections;
     
    public class Trigger : MonoBehaviour {
     

        void OnMouseDown()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            //GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        }

        public Dialogue dialogue;

        
    }
