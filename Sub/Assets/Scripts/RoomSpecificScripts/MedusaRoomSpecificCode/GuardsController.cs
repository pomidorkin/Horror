using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardsController : MonoBehaviour
{
    private StoneEnemy[] enemies;

    private void OnEnable()
    {
        enemies = FindObjectsOfType<StoneEnemy>();
    }

    public StoneEnemy[] GetEnemies()
    {
        return enemies;
    }
}
