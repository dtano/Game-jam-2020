using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDetector : MonoBehaviour
{
    public GameObject linkController;
    void Start(){

    }

    void Update(){

    }
    
    public void getCurrentObject(){
        Button currentButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        currentButton.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log(currentButton.name);
        currentButton.interactable = false;

        
        
    }
}
