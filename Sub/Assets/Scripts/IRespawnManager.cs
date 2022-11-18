using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

interface IRespawnManager
{
    void Respawn(AiScreamerController enemy);
    void PlayRespawnUIAnim();
}
