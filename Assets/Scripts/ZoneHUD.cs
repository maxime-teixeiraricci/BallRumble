using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneHUD : MonoBehaviour
{
    public Vector3 offset;
    public ZoneScript zone;
    public Image gauge;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(zone.transform.position + offset) ;
        gauge.fillAmount = zone.value / 100f;
        gauge.color = zone.GetComponent<MeshRenderer>().material.color;
	}
}
