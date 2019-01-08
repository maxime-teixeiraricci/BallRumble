using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public Vector2 direction;
    private float t;

	
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;
        GetComponent<MeshRenderer>().material.mainTextureOffset = direction * t;
	}
}
