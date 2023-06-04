using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnType : MonoBehaviour
{
    public ActionBasedSnapTurnProvider snapT;
    public ActionBasedContinuousTurnProvider continuousT;

    public  void  SetTypeFromIndex(int index)
    {
        if(index == 0)
        {
            snapT.enabled = false;
            continuousT.enabled = true;
        }
        else if(index == 1)
        {
            snapT.enabled = true;
            continuousT.enabled = false;
        }
    }
}
