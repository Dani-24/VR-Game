using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject objectToSpawn;

    public Transform playerPos;

    public float dist = 2;

    public float altura = 1;

    public void Spawn(string objectName)
    {

        Vector3 posAPoner = new Vector3(playerPos.position.x, altura, playerPos.position.z);

        objectToSpawn.transform.position = posAPoner + playerPos.transform.forward * dist;
        Quaternion newRotation = Quaternion.Euler(objectToSpawn.transform.rotation.eulerAngles.x, playerPos.rotation.eulerAngles.y, objectToSpawn.transform.rotation.eulerAngles.z);

        objectToSpawn.transform.rotation = newRotation;

        objectToSpawn.SetActive(objectName == "o");
    }
}
