using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System;

public class LinkControl : MonoBehaviour
{
    Button firstItem;
    Button secondItem;

    Button[] selectedItems;
    public LinkStore linkStorage;

    private LinkArray[] links;
    
    // Which link the firstItem belongs to
    private int linkIndex;
    // Start is called before the first frame update
    void Start()
    {
        links = linkStorage.GetLinks();
    }

    // Update is called once per frame
    void Update()
    {
        if(firstItem != null){
            //Debug.Log(firstItem);
        }

        if(secondItem != null){
            //Debug.Log(secondItem);
        }
    }

    public bool attach(Button item){
        if(firstItem == null){
            firstItem = item;
            for(int i = 0; i < links.Length; i++){
                if(links[i].find(item)){
                    selectedItems = new Button[links[i].Length() - 1];
                    linkIndex = i;
                    Debug.Log("Link has been found, length of available selected items is " + selectedItems.Length);
                    return true;
                }
            }
        }else if(firstItem != null && selectedItems != null){
            for(int i = 0; i < selectedItems.Length; i++){
                if(selectedItems[i] == null){
                    selectedItems[i] = item;
                    return true;
                }
            }
           

        }
        // else if(firstItem != null && secondItem == null){
        //     secondItem = item;
        //     return true;
        // }
        
        return false;

    }

    public void restoreLinks(GameObject page){
        if(firstItem != null && firstItem.transform.parent == page){
            firstItem.interactable = false;
        }

        if(selectedItems != null){
            for(int i = 0; i< selectedItems.Length; i++){
                if(selectedItems[i].transform.parent == page){
                    selectedItems[i].interactable = false;
                }
            }
        }

        // if(secondItem != null && secondItem.transform.parent == page){
        //     secondItem.interactable = false;
        // }
    }

    
}
