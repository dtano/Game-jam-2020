    using UnityEngine;
    using System.Collections;
     
    public class Trigger : MonoBehaviour {
     
        public Dialogue dialogue;
        void OnMouseDown()
        {
            //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            //GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
            
            this.GetComponent<Clickable>().enabled = true;
            Debug.Log("Object pressed");
        }

        
    }
