using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public GameObject Player;
    public Dialogue dialogue;
    public bool clicked = false;
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
        StopAllCoroutines();
        StartCoroutine(MoveToObject(Player.transform));
    }

    IEnumerator MoveToObject(Transform target){
        while(Mathf.Abs(transform.position.x - target.position.x) > 0.5f){
            yield return null;
        }

        Debug.Log("Reached the target");
        // Trigger the dialogue and freeze the player
        //GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    
        
        Debug.Log("Coroutine is now finished");
        //GameObject.Find("Player").GetComponent<playerMovement>().enabled = true;
        
        // Disables the coroutine
        enabled = false;
        StopCoroutine(MoveToObject(target));


    }

    
}