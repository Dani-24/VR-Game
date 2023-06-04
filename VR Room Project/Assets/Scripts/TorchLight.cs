using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioSource sfx;
    public bool activedChild = false;
    void Start()
    {
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Torch" && !activedChild )
        {
            activedChild = true;
            sfx.Play();

            //other.gameObject.SetActive(false);
           // gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

    }
}
