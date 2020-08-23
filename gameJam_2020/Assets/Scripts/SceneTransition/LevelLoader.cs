using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(){
        animator.SetTrigger("FadeOut");
    }

    public void FadeToQuit(){
        animator.SetTrigger("Quit");
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
