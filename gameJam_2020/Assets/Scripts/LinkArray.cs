using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class LinkArray : MonoBehaviour
{
    public Button[] links;
    
    public int Length(){
        return links.Length;
    }

    public bool find(Button item){
        for(int i = 0; i < links.Length; i++){
            Debug.Log(links[i]);
            if(Array.Exists(links, element => element == item)){
                return true;
            }
        }
        return false;
    }

    
}
