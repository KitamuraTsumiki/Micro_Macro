﻿using UnityEngine;
/// <summary>
/// this class sets transform of the UI canvas
/// </summary>
public class UITransformModifier : MonoBehaviour {

    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float dist;
    [SerializeField]
    private float height;
    [SerializeField]
    private float localXAngle;
    private Vector3 AngleInEulerAndDegrees;

    private void Update () {
        ConvertAngle();
        SetPosition();
        FaceCanvas();
    }

    private void ConvertAngle()
    {
        AngleInEulerAndDegrees = cameraTransform.rotation.eulerAngles;
    }

    private void FaceCanvas()
    {
        transform.localRotation = Quaternion.Euler(localXAngle, AngleInEulerAndDegrees.y, 0f);
    }

    private void SetPosition()
    {
        Vector3 normalizedForwardVec = new Vector3(cameraTransform.forward.x, 0f, cameraTransform.forward.z).normalized;
        float x = normalizedForwardVec.x * dist + cameraTransform.position.x;
        float y = height;
        float z = normalizedForwardVec.z * dist + cameraTransform.position.z;

        transform.position = new Vector3(x, y, z);
        
    }
    
}
