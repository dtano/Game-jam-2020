using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFor : MonoBehaviour
{
    public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        StopAllCoroutines();
        StartCoroutine(waitBeforeExit());
    }

    IEnumerator waitBeforeExit(){
        yield return new WaitForSeconds(5f);
        levelLoader.FadeToQuit();
        //yield return new WaitForSeconds(3f);
        //levelLoader.GetComponent<GameExit>().QuitGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
