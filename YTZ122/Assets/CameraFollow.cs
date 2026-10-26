using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Cameraspeed = 5;

    public float minX, maxX;
    public float minY, maxY;

    void LateUpdate()
    {
        if (Target == null) return;

        Vector3 desired = new Vector3(Target.position.x, Target.position.y, -10f);
        Vector3 smoothed = Vector3.Lerp(transform.position, desired, Cameraspeed * Time.deltaTime);

        smoothed.x = Mathf.Clamp(smoothed.x, minX, maxX);
        smoothed.y = Mathf.Clamp(smoothed.y, minY, maxY);
        smoothed.z = -10f;

        transform.position = smoothed;
    }
}