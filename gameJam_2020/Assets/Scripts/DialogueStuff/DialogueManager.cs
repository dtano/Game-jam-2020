using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText; 

    public Animator animator;

    private Queue<string> sentences;
    
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Text box started");

        GameObject.Find("Player").GetComponent<playerMovement>().stop();
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }    

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
             EndDialogue();
             return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Go through text one letter at a time
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        
        animator.SetBool("IsOpen", false);
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = true;
    
    }

    
}