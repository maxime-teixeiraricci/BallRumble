using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    public float speed;


	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().color = new Color(1f, 1f, 1f, (Mathf.Cos(Time.time * speed)+1)/2f);
	}
}
