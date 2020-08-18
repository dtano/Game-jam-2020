using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    // To prevent the player sprite from moving on its own at the start 
    private bool noMove = false;
    
    //public Animator animator;

    private bool faceRight = true;

    private Vector2 target;
    // private Vector2 position;
    // private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        // target = new Vector2(0.0f, 0.0f);
        // position = gameObject.transform.position;

        // cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {   
        // //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        //float move = Input.GetAxis("Horizontal");
        // Vector3 movement = new Vector3(move, 0f, 0f);
        // transform.position += movement * Time.deltaTime * moveSpeed;

        // animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime ));

        // //Flip the character
        // if(move < 0 && faceRight){
        //     flip();
        // }else if(move > 0 && !faceRight){
        //     flip();
        // }

        // Getting the coordinates of the mousePosition in game

        // float step = moveSpeed * Time.deltaTime;
        // transform.position = Vector2.MoveTowards(transform.position, target, step);
        // Debug.Log(target);
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(Input.GetMouseButtonDown(0)){
            target = new Vector2(mousePos.x, transform.position.y);
            noMove = true;
        }

        if(noMove == true){
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
        }
        //transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);

        //animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime ));

        // if(target != null){
        //     if(Mathf.Sign(transform.position.x) != Mathf.Sign(target.x)){
        //         Debug.Log("Target is in the opposite direction");
        //         flip();
        //     }else{
        //         Debug.Log("Target is in the same direction");
        //     }
        // }

        
    }

    void flip(){
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    // void OnGUI(){
    //     Event currentEvent = Event.current;
    //     Vector2 mousePos = new Vector2();
    //     Vector2 point = new Vector2();

    //     // compute where the mouse is in world space
    //     mousePos.x = currentEvent.mousePosition.x;
    //     mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
    //     point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // set the target to the mouse click location
    //         target = point;
    //     }
    // }

    
}
