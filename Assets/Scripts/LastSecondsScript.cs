using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastSecondsScript : MonoBehaviour
{
    public TimerHUD timer;
	
	
	// Update is called once per frame
	void Update ()
    {
        float t = BattleManager.instance.time;
        t = Mathf.Max(0, t);
        if (t < 10 && t != 0)
        {
            GetComponent<Text>().text = "" + ((int)t + 1);
        }
        else if (t ==0)
        {
            GetComponent<Text>().text = "TIME";
        }
        else
        {
            GetComponent<Text>().text = "";
        }
	}
}
