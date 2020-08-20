using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The player thats being followed
    public Transform target;
    
    // The limit before the camera moves right
    private float horzExtent;
    public float speed = 2 ;
    
    //private Vector3 destination;

    // The x position of the camera
    private float cameraX;
    
    // The x position that the camera should go to
    private Vector3 dest;
    
    private Vector3 originalPosition;
    
    // Stops the camera from moving
    private bool stopMove = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        
        originalPosition = transform.position;

        
        cameraX = transform.position.x;
        dest = transform.position;

        Debug.Log(horzExtent);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        // Case when the player has walked past the camera's right bounds
        if(target.position.x > horzExtent + 1 && !stopMove){
            cameraX += speed * Time.deltaTime;
            if(cameraX > originalPosition.x + 4){
                Debug.Log("Camera should stop");
                stopMove = true;
            }
        
            //dest.x = cameraX;
            //transform.position = dest;
        }

        // Case when the player wants to go back
        if(stopMove && target.position.x < horzExtent){
            cameraX -= speed * Time.deltaTime;
            if(cameraX <= originalPosition.x){
                Debug.Log("Camera moving back");
                stopMove = false;
            }
        }



        dest.x = cameraX;
        transform.position = dest;

        
    }
}
