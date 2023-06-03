using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVROrNot : MonoBehaviour
{
    public GameObject XRPlayer;
    public GameObject NoVRPlayer;

    private bool isOnXRDevice = false;

    private void Awake()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            isOnXRDevice = true;
        }

        if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            isOnXRDevice = false;
        }

        XRPlayer.SetActive(isOnXRDevice);
        NoVRPlayer.SetActive(!isOnXRDevice);
    }
}
