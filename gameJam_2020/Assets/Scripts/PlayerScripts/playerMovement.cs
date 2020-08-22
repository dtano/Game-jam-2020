using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    // To prevent the player sprite from moving on its own at the start 
    private bool noMove = false;
    
    public Animator animator;

    private Rigidbody2D body;

    private bool faceRight = true;

    private Vector2 target;
    // private Vector2 position;
    // private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        // target = new Vector2(0.0f, 0.0f);
        // position = gameObject.transform.position;
        body = GetComponent<Rigidbody2D>();
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

        // Getting the coordinates of the mousePosition in game
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(Input.GetMouseButtonDown(0)){
            target = new Vector2(mousePos.x, transform.position.y);
            // If target.x's sign != transform.x then flip
            // This doesn't work
            float direction = target.x - transform.position.x;

            if(faceRight && target.x < transform.position.x){
                flip();
            }else if(!faceRight && target.x > transform.position.x){
                flip();
            }
            noMove = true;
        }

        if(noMove == true){
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
            //body.MovePosition(new Vector2(target.x * moveSpeed * Time.deltaTime,
            //transform.position.y));
            float direction = target.x - transform.position.x;
            animator.SetFloat("Horizontal", Mathf.Abs(direction * moveSpeed * Time.deltaTime ));
        }

        // Vector3 tmpPos = Camera.main.WorldToScreenPoint (transform.position);
        // if(tmpPos.x > Screen.width){
        //     Vector3 position = transform.position;
        //     //position.x = 12;
        //     //transform.position = position;
        //     Debug.Log("Player has reached the end");
        // }

        

        // float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        // Camera cam = Camera.main;
        // float boundWidth = cam.orthographicSize;
        //Debug.Log(horzExtent);
        //Debug.Log(boundWidth);

        // A rather hacky solution
        // The player is placed in a player layer and the furniture is placed in a furniture layer
        // This will ignore collisions between these 2 layers
        Physics2D.IgnoreLayerCollision(8,9);
        Physics2D.IgnoreLayerCollision(9,10);

       

        
    }
    /*Doesn't work 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "LeftWall"){
            Debug.Log("Collision");
        }
    }
    */



     //Create raycast to check whether there is wall in front of player    
    void FixedUpdate()
    {
        //Length of the ray
        float laserLength = 1f;
    
        int layerMask = LayerMask.GetMask("Default");
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target, laserLength, layerMask);
 
        
        if (hit.collider != null)
        {
            
            Debug.Log("Hitting: " + hit.collider.tag);
            animator.SetFloat("Horizontal", 0);
            target = new Vector2(transform.position.x, transform.position.y);
        }
        
        Debug.DrawRay(transform.position, target * laserLength, Color.red);
    }
    
    
    void flip(){
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void stop(){
        animator.SetFloat("Horizontal", 0);
        target = new Vector2(transform.position.x, transform.position.y);
        enabled = false;
    }

    
}
