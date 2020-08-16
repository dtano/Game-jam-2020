using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    private GameObject player;
    public float offset;

    private float originalY;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Stores current camera position in a temp variable
        Vector3 temp = transform.position;
        
        // Set the camera's x to the player's x
        temp.x = playerTransform.position.x;

        /*
        if(player.GetComponent<playerMovement>().isGrounded == false){
            temp.y = playerTransform.position.y - originalY;
        }
        */
        
        temp.y = playerTransform.position.y + 1;

        // This will add the offset value to the temp camera posiiton
        temp.x += offset;

        // Set the camera's temp position back to the camera's current position 
        transform.position = temp;


    }
}
