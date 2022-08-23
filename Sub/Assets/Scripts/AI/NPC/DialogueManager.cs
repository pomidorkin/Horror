using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Dialogue currentDialogue;
    [SerializeField] GameObject dialogueElement;
    [SerializeField] TMP_Text dialogueText;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueElement.SetActive(true);
        currentDialogue = dialogue;
        // Make Dialogue canvas element active
        sentences.Clear();
        if (dialogue.wasTalkedTo)
        {
            // Display dialogue.repeatableSentence
            dialogueText.text = dialogue.repeatableSentence;
        }
        else
        {
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
    }

    public void EndDialogue()
    {
        currentDialogue.wasTalkedTo = true;
        dialogueElement.SetActive(false);
        // Make Dialogue canvas element inactive
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        Debug.Log(sentence);
    }
}
