using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Stage", fileName = "Stage")]
public class Stage : ScriptableObject
{
    public StageType currentStage;
    public GoalType goalType;
    public StageLocationType stageLocationType;
    public StageGoal stageGoal;
    public string questText;
    public enum StageType { respawnStage, stageOne, stageTwo, stageThree, stageFour, stageFive, stageSix, stageSeven };
    public enum GoalType { amountGoal, interactGoal, bothAmountInteract, doorsAndAmount};
    public enum StageLocationType { room, corridor, decoration }
}
