using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDisplayer : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    
    public Animator animator;
    
    private Queue<string> sentences;
    private string talkerName;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && animator.GetBool(("isOpen")))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        
        sentences.Clear();
        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(SentenceTypingCoroutine(sentence));
    }

    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

    IEnumerator SentenceTypingCoroutine(string sentence)
    {
        dialogText.text = "";
        foreach (char character in sentence)
        {
            dialogText.text += character;
            yield return null;
        }
    }
}
