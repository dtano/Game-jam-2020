﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LinkStore : MonoBehaviour
{

    // [System.Serializable]
    // public struct buttonStruct {
    //     [SerializeField] public Button[] buttons;
    // }
    public List<LinkArray> listOfLinks;
    //public buttonStruct[] listOfLinks;
    // Start is called before the first frame update
    void Start()
    {
        // links = new Dictionary<Button, Button>(){
        // {GameObject.Find("Threat").GetComponent<Button>(), GameObject.Find("Professor_disappearance").GetComponent<Button>()},
        // {GameObject.Find("Professor_disappearance").GetComponent<Button>(), GameObject.Find("Threat").GetComponent<Button>()}
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }


    public List<LinkArray> GetLinks(){
        return listOfLinks;
    }

    
    public int length(){
        return listOfLinks.Count;
    }
}
