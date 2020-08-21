using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransfer : MonoBehaviour
{
    public bool active = false;
    public Dialogue dialogue;

    void OnMouseDown()
        {

            if(active){
                Transform transform = GameObject.Find("Player").transform;
                StopAllCoroutines();
                StartCoroutine(leaveLevel(transform));
            
            
                Debug.Log("Object pressed");
            }
            
        }
    IEnumerator leaveLevel(Transform target){
            while(Mathf.Abs(transform.position.x - target.position.x) > 1.0f){
                yield return null;
            }

            Debug.Log("Reached the target");
            // Trigger the dialogue and freeze the player
            //GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;

            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            
            // Waits until the dialogue has ended before giving the item
            while(FindObjectOfType<DialogueManager>().animator.GetBool("IsOpen") == true){
                yield return null;
            }

            // Play door sound effect

            // Leaving next level
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel();
    
            
            Debug.Log("Coroutine is now finished");
            //GameObject.Find("Player").GetComponent<playerMovement>().enabled = true;
        
            // Disables the coroutine
            enabled = false;
            StopCoroutine(leaveLevel(target));


    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
