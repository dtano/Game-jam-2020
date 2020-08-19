using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public GameObject Player;
    public Dialogue dialogue;
    public bool clicked = false;
    public float dist;
    //public float dist;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Coroutine start");
        //StartCoroutine(MoveToObject(Player.transform));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void initCoroutine(){
        Debug.Log("Coroutine start");
        StartCoroutine(MoveToObject(Player.transform));
        
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //GameObject.Find("Player").GetComponent<playerMovement>().enabled = true;
        
    }

    IEnumerator MoveToObject(Transform target){
        
        
        while(Mathf.Abs(transform.position.x - target.position.x) > 0.5f){
            Debug.Log("Player not there yet");
            /*
            dist = Mathf.Abs(transform.position.x - target.position.x) ;
            if (dist <= 0.05f){
                this.GetComponent<Trigger>().DialogueStart();
            }
            */
            yield return null;
        }

        
        Debug.Log("Reached the target");
        // Trigger the dialogue and freeze the player
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
        yield return new WaitForSeconds(0.01f);
        
        Debug.Log("Coroutine is now finished");
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = true;
        
        // Disables the coroutine
        enabled = false;


    }

    
}
