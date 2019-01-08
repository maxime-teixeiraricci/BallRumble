using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAnimation : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset  += new Vector2(0, Time.deltaTime * speed);
	}
}
