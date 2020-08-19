using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public GameObject Player;
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
        StartCoroutine(MoveToObject(Player.transform));
    }

    IEnumerator MoveToObject(Transform target){
        while(Mathf.Abs(transform.position.x - target.position.x) > 0.05f){
            Debug.Log("Player not there yet");
            yield return null;
        }

        Debug.Log("Reached the target");
        // Trigger the dialogue and freeze the player
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        
        yield return new WaitForSeconds(3f);
        
        Debug.Log("Coroutine is now finished");
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = true;
        
        // Disables the coroutine
        enabled = false;


    }

    
}
