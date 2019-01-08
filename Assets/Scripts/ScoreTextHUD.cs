using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextHUD : MonoBehaviour
{
    public RollingBall player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = transform.parent.GetComponent<PlayerControler>().target.GetComponent<RollingBall>().score.ToString("00");
    }
}
