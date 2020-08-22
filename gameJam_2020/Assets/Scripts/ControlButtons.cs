using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButtons : MonoBehaviour
{
    GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableButtons(Button exemptButton){
        exemptButton.interactable = false;
        for(int i = 0; i < buttons.Length; i++){
            if(buttons[i] != exemptButton){
                buttons[i].GetComponent<Button>().enabled = false;
            }
            //buttons[i].GetComponent<Button>().enabled = false;
            
        }
    }

    public void activateButtons(){
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].GetComponent<Button>().enabled = true;
        }
    }
}
