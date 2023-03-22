using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODHighBypass : MonoBehaviour
{
    FMOD.Studio.EventInstance instance;

    [FMODUnity.EventRef]
    public string fmodEvent;

    private void Start()
    {
        
        
    }

    public void PlayBypassEffect(bool value)
    {
        if (value)
        {
            //instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
            instance.start();
            instance.release();
        }
        else
        {
            //instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
            //instance.start();
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release(); //?
        }
    }
}
