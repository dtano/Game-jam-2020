    using UnityEngine;
    using System.Collections;
     
    public class Trigger : MonoBehaviour {
     

        void OnMouseDown()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        public Dialogue dialogue;

        
    }
