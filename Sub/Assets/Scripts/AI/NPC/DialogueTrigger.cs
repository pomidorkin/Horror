using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] Dialogue dialogue;

    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this);
        dialogueManager.StartDialogue(dialogue, this);
        inputManager.MakeMouseVisible(true);
    }
}
