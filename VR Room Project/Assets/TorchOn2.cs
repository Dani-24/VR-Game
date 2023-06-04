using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchOn2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource sfx;
    private bool activedChild = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Torch" && other.gameObject.GetComponent<TorchLight>().activedChild && !activedChild)
        {
            sfx.Play();
            activedChild = true;
            //other.gameObject.SetActive(false);
            // gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

    }
}
