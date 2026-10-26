using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera Cam;
    public float TargetZoom = 3;   // the zoom I want (camera size)
    private float ScrollData;      // value collected from the mouse wheel
    public float ZoomSpeed = 3;    // speed of zooming in or out

    void Start()
    {
        Cam = GetComponent<Camera>();
        TargetZoom = Cam.orthographicSize;   // start with the default camera size
    }

    void Update()
    {
        // returns 0 when the wheel is still, +ve scrolling forward, -ve scrolling backward
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        TargetZoom = TargetZoom - ScrollData;

        // limits so we don't zoom too much
        TargetZoom = Mathf.Clamp(TargetZoom, 3, 10);

        // smooth transition from current size to target size
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }
}