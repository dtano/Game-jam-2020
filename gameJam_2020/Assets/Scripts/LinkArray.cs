using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class LinkArray : MonoBehaviour
{   
    public List<Button> links;
    public Dialogue dialogue;
    
    

    public int Length(){
        return links.Count;
    }


    public bool find(Button item){
        foreach(Button button in links){
            if(links.Contains(item)){
                return true;
            }
        }
        return false;
    }

    
}
