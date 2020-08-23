using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{


    public GameObject gabriel;
    public GameObject marker;
    
    public Animator gabrielAnimator;
    public Dialogue openingDialogue;

    private Vector2 target;
    
    private bool reached = false;
    private bool gabrielMove = true;

    private float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
        target = marker.transform.position;
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        FindObjectOfType<DialogueManager>().StartDialogue(openingDialogue);
        
        gabrielAnimator.SetBool("move", true);
        //gabrielMove = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!reached)
        {
            gabriel.transform.position = Vector2.MoveTowards(gabriel.transform.position, target, Time.deltaTime * moveSpeed);
            //float direction = target.x - gabriel.transform.position.x;
            gabrielAnimator.SetBool("move", true);
            //gabrielAnimator.SetFloat("Horizontal", Mathf.Abs(direction * moveSpeed * Time.deltaTime));
            
        }
        float distance = (gabriel.transform.position.x - target.x);
        //Debug.Log(distance);
        
        if(distance <= 2)
        {   
            gabrielMove = false;
            //gabrielAnimator.SetFloat("Horizontal", 0);
            gabrielAnimator.SetBool("move", false);
            //gabrielAnimator.SetBool("move", false);
            //target = new Vector2(gabriel.transform.position.x, gabriel.transform.position.y);
            reached = true;
            
        }
        Physics2D.IgnoreLayerCollision(8,10);
        
    }
    

    
}
