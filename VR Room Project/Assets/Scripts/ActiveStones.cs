using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActiveStone()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {

            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
