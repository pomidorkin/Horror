using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/New NPC Dialogue", fileName = "New NPC Dialogue")]
public class Dialogue : ScriptableObject
{
    public bool wasTalkedTo = false;
    public string NPCName = "";
    [TextArea(3,10)]
    public string[] sentences;
    [TextArea(3, 10)]
    public string repeatableSentence;
}
