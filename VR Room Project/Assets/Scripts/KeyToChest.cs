using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToChest : MonoBehaviour
{
    // Start is called before the first frame
    // 
    [SerializeField] private AudioSource sfx;
    void Start()
    {
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Key")
        {
             sfx.Play();
        
             other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        
    }
}
