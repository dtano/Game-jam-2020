using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Animator animator;

    private bool faceRight = true;

    private Vector2 target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        float move = Input.GetAxis("Horizontal");
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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(Input.GetMouseButtonDown(0)){
            target = new Vector2(mousePos.x, transform.position.y);
            Debug.Log(target);
        }

        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);

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

    
}
