using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    // Start is called before the first frame update

    public bool full(){
        int fullSlots = 0;
        for(int i = 0; i < isFull.Length; i++){
            if(isFull[i] == true){
                fullSlots += 1;
            }
        }
        
        if(fullSlots == isFull.Length){
            return true;
        }
        return false;
    }

    
}
