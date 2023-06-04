using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class StoneToSphere : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource sfx;
    private bool stoned = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag(other.gameObject.tag) && !stoned)
        {
            stoned = true;
            sfx.Play();

            other.gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
           
        }

    }

   
}
