using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTPRay : MonoBehaviour
{
    public GameObject leftTP;
    public GameObject rightTP;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    void Update()
    {
        leftTP.SetActive(leftActivate.action.ReadValue<float>() > 0.1f);
        rightTP.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
