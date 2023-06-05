using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelojTrigger : MonoBehaviour
{
    public string desiredTag;
    public bool isTriggered;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == desiredTag)
        {
            isTriggered = true;
        }
        else
        {
            isTriggered = false;
        }
    }
}
