using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Dialogue currentDialogue;
    private DialogueTrigger currentDialogueTrigger;
    [SerializeField] GameObject dialogueElement;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] float radius = 3f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject interactionText;
    [SerializeField] InputManager inputManager;
    [SerializeField] Animator animator;
    private float radiusSqrd;

    void Start()
    {
        sentences = new Queue<string>();
        radiusSqrd = radius * radius;
    }

    private void Update()
    {
        if (currentDialogueTrigger != null && radiusSqrd < Mathf.Pow((currentDialogueTrigger.transform.position.x - player.transform.position.x), 2) && dialogueElement.activeInHierarchy)
        {
            dialogueElement.SetActive(false);
        }
        
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger trigger)
    {
        dialogueElement.SetActive(true);
        interactionText.SetActive(false);
        animator.Play("DialogueOpen");
        currentDialogue = dialogue;
        currentDialogueTrigger = trigger;
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
        animator.Play("DialogueClosed");
        /*interactionText.SetActive(true);
        currentDialogue.wasTalkedTo = true;
        dialogueElement.SetActive(false);
        inputManager.MakeMouseVisible(false);*/
        // Make Dialogue canvas element inactive
    }

    public void HideDialogue()
    {
        interactionText.SetActive(true);
        currentDialogue.wasTalkedTo = true;
        dialogueElement.SetActive(false);
        inputManager.MakeMouseVisible(false);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        Debug.Log(sentence);
    }

    private IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
}
