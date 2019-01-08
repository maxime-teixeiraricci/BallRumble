using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform target;
    public bool isMoving;
    public bool reverse;

    private float t;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime * speed * ((isMoving)? 0:1) * ((reverse) ? -1 : 1);
        transform.position = target.position + new Vector3(distance * Mathf.Cos(t), 0, distance * Mathf.Sin(t));
        transform.LookAt(target);
	}
}
