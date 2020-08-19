    using UnityEngine;
    using System.Collections;
     
    public class Trigger : MonoBehaviour {
     
        //public Dialogue dialogue;
        void OnMouseDown()
        {
            
            //GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
            
            this.GetComponent<Clickable>().enabled = true;
            
            this.GetComponent<Clickable>().initCoroutine();
            
            
            Debug.Log("Object pressed");
        }

        /*
        public void DialogueStart()
        {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        */
        
    }
