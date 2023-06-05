using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using PDollarGestureRecognizer;
using System.IO;
using UnityEngine.Events;

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    public Transform movementSource;

    public float newPositionThresholdDistance = 0.05f;
    public GameObject drawingObjectPrefab;

    public bool creationMode = true;
    public string newGestureName;
    private List<Gesture> trainingSet = new List<Gesture>();

    public float recognitionThreshold = 0.9f;

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> { }
    public UnityStringEvent OnRecognized;

    private bool isMoving = false;
    private List<Vector3> positionList = new List<Vector3>();

    public TextAsset canvasCode;

    public float drawingDuration = 2f;

    private void Start()
    {
        trainingSet.Add(GestureIO.ReadGestureFromXML(canvasCode.ToString()));
    }

    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);

        if(!isMoving && isPressed)
        {
            StartMovement();
        }
        else if(isMoving && !isPressed)
        {
            EndMovement();
        }
        else if(isMoving && isPressed)
        {
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        Debug.Log("Start movement");
        isMoving = true;

        positionList.Clear();
        positionList.Add(movementSource.position);

        if (drawingObjectPrefab)
        {
            Destroy(Instantiate(drawingObjectPrefab, movementSource.position, Quaternion.identity),drawingDuration);
        }
    }

    void EndMovement()
    {
        Debug.Log("End movement");
        isMoving = false;

        Point[] pointArray = new Point[positionList.Count];

        for(int i = 0; i< positionList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionList[i]);
            pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);
        }

        Gesture newGesture = new Gesture(pointArray);

        if(creationMode)
        {
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);

            string fileName = Application.persistentDataPath + "/" + newGestureName + ".xml";
            GestureIO.WriteGesture(pointArray, newGestureName, fileName);
        }
        else
        {
            Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
            Debug.Log(result.GestureClass + result.Score);

            if(result.Score > recognitionThreshold)
            {
                OnRecognized.Invoke(result.GestureClass);
            }

        }
    }

    void UpdateMovement()
    {
        Debug.Log("Update movement");

        Vector3 lastPosition = positionList[positionList.Count - 1];

        if (Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionList.Add(movementSource.position);

            if (drawingObjectPrefab)
            {
                Destroy(Instantiate(drawingObjectPrefab, movementSource.position, Quaternion.identity), 2f);
            }
        }
    }
}
