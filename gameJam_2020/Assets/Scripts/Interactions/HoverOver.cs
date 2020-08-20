using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOver : MonoBehaviour
{

    public GameObject hoverOver;
    // Start is called before the first frame update
    public void Start()
    {
        hoverOver.SetActive(false);
    }

    public void OnMouseOver() {
        hoverOver.SetActive(true);
    }

    public void OnMouseExit(){
        hoverOver.SetActive(false);
    }
        
    
}
