    using UnityEngine;
    using System.Collections;
     
    public class Trigger : MonoBehaviour {
     

        void OnMouseDown()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            //GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
            Debug.Log("Object pressed");
        }

        public Dialogue dialogue;

        
    }
