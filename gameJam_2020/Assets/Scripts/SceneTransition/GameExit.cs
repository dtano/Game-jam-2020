using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void QuitGame(){
        if(UnityEditor.EditorApplication.isPlaying == true){
            UnityEditor.EditorApplication.isPlaying = false;

        }else{
            Application.Quit();
        }
    }
}
