using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMenu : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;

    public void CloseDialogueAnimationFinished()
    {
        dialogueManager.HideDialogue();
    }
}
