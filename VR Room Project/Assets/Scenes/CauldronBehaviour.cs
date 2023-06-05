using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBehaviour : MonoBehaviour
{
    [SerializeField] private Color defaultGoodColor;
    [SerializeField] private Color defaultBadColor;
    [SerializeField] private Color goodColor;
    [SerializeField] private Color badColor;

    [SerializeField] private Material soupMat;

    void Start() 
    {
        soupMat.color = defaultGoodColor;
    }

}
