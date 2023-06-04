using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject canvas;
    public Animator animator;

    public void CloseUIButton()
    {
        canvas.SetActive(false);
    }
}
