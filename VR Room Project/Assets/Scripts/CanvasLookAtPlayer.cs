using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLookAtPlayer : MonoBehaviour
{
    public Transform playerHead;

    void Update()
    {
        transform.LookAt(new Vector3(playerHead.position.x, playerHead.position.y, playerHead.position.z));
        transform.forward *= -1;
    }
}
