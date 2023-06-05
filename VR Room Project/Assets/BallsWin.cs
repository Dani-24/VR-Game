using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsWin : MonoBehaviour
{
    public GameObject UIToCreate;
    void Update()
    {
        

        if(gameObject.transform.GetChild(0).gameObject.GetComponent<StoneToSphere>().stoned &&gameObject.transform.GetChild(1).gameObject.GetComponent<StoneToSphere>().stoned &&gameObject.transform.GetChild(2).gameObject.GetComponent<StoneToSphere>().stoned )
        {
            GameObject.Find("SFXpuzle").gameObject.GetComponent<AudioSource>().Play();
            UIToCreate.SetActive(true);
        }

            
    }
}
