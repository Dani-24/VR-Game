using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Caldero")
        {

        }
        else if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
