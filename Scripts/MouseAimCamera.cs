using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimCamera : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 5;
    public float maxZoom = -10;
    public float minZoom = -2;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.transform.position;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);

        Vector2 zoom = Input.mouseScrollDelta;
        offset.z += zoom.y;

        offset.z = Math.Max(maxZoom, offset.z);
        offset.z = Math.Min(minZoom, offset.z);

        transform.LookAt(target.transform);
    }
}
