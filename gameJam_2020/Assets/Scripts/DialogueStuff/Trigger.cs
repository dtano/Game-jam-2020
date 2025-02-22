﻿    using UnityEngine;
    using System.Collections;
     
    public class Trigger : MonoBehaviour {

        private int num;

        public bool active;
     
        public Dialogue dialogue;
        void OnMouseDown()
        {

            if(active){
                Transform transform = GameObject.Find("Player").transform;
                StopAllCoroutines();
                StartCoroutine(MoveToObject(transform));
            
            
                Debug.Log("Object pressed");
            }
            
        }

        /*
        public void DialogueStart()
        {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        */

        IEnumerator MoveToObject(Transform target){
            while(Mathf.Abs(transform.position.x - target.position.x) > 1.0f){
                yield return null;
            }

            Debug.Log("Reached the target");
            // Trigger the dialogue and freeze the player
            //GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Debug.Log("Dialogue started");
    
            
            Debug.Log("Coroutine is now finished");
            //GameObject.Find("Player").GetComponent<playerMovement>().enabled = true;
        
            // Disables the coroutine
            enabled = false;
            StopCoroutine(MoveToObject(target));


        }
        
    }
