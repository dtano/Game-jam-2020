using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangePage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameObject.Find("NextPage").name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Change the inventory page
    public void change(){
        GameObject nextButton = EventSystem.current.currentSelectedGameObject;
        if(nextButton.transform.parent.tag == "Main Board"){
            deactivatePage(GameObject.Find("Background"));
            activatePage(GameObject.Find("NextPage"));
        }else if(nextButton.transform.parent.tag == "Additional Board"){
            deactivatePage(GameObject.Find("NextPage"));
            activatePage(GameObject.Find("Background"));
        }
    }

    // Deactivates all the items on the page
    void deactivatePage(GameObject page){
        Transform transform = page.transform;
        foreach(Transform child in transform){
            child.gameObject.SetActive(false);
        }
    }

    // Activates all the items on the page
    void activatePage(GameObject page){
        Transform transform = page.transform;
        foreach(Transform child in transform){
            child.gameObject.SetActive(true);
        }
    }
}
