using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonDetector : MonoBehaviour
{
    void Start(){

    }

    void Update(){

    }
    
    public void getCurrentObject(){
        Debug.Log(EventSystem.current.currentSelectedGameObject);
    }
}
