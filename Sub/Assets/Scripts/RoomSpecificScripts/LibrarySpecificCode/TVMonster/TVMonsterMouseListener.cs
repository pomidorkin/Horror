using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVMonsterMouseListener : MouseInterface
{
    [SerializeField] PlayerTVMonsterController playerTVMonsterController;
    public override void LeftButtonPressed()
    {
        playerTVMonsterController.MouseClickedHandler();
    }
}
