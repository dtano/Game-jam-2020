using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float horzExtent;
    public float speed = 1 ;
    
    private Vector3 destination;
    private Vector3 projection;

    private float cameraX;
    private Vector3 dest;
    
    
    
    private Vector3 originalPosition;
    private bool stopMove = false;
    // Start is called before the first frame update
    void Start()
    {
        horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        destination = transform.position;
        originalPosition = transform.position;

        projection = target.position;
        cameraX = transform.position.x;
        dest = transform.position;

        Debug.Log(horzExtent);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        projection = Vector3.MoveTowards(projection, target.position, Time.deltaTime * speed);
        

        if(target.position.x > horzExtent && !stopMove){
            cameraX += speed * Time.deltaTime;
            if(cameraX > originalPosition.x + 4){
                Debug.Log("Camera should stop");
                stopMove = true;
            }
        
            //dest.x = cameraX;
            //transform.position = dest;
        }

        dest.x = cameraX;
        transform.position = dest;

        // if((target.position - projection).magnitude > horzExtent){
            
        //     projection = Vector3.MoveTowards(projection, target.position, Time.deltaTime * speed);
        //     destination = projection;
        //     transform.position = destination;
        // }
    
    }
}
