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
        StartCoroutine(MoveToObject(Player.transform));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator MoveToObject(Transform target){
        while(Mathf.Abs(transform.position.x - target.position.x) > 0.05f){
            Debug.Log("Player not there yet");
            yield return null;
        }

        Debug.Log("Reached the target");

        yield return new WaitForSeconds(3f);
        Debug.Log("Coroutine is now finished");
        enabled = false;


    }

    
}
