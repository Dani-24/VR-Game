using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrab : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //This locks the RigidBody so that it does not move or rotate in the Z axis.
        //m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DesConstraint()
    {
        m_Rigidbody.constraints = RigidbodyConstraints.None;
    }
}
