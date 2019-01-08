using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public Vector3 deltaVect;
    public float distance;
    public float speed;

    private float t;

    private void LateUpdate()
    {
        t += Time.deltaTime * speed;
        transform.position = new Vector3(distance * Mathf.Cos(t), 0, distance * Mathf.Sin(t)) + deltaVect;
        transform.LookAt(Vector3.zero);
    }
}
