using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHUD : MonoBehaviour
{
    public float timerStart;
    public float t;


	
	// Update is called once per frame
	void Update ()
    {
        t = Mathf.Max(BattleManager.instance.time, 0);


        int min = (int)(t / 60);
        int sec = (int)(t % 60);
        if (min != 0)
        {
            GetComponent<Text>().text = "" + min.ToString("00") + ":" + sec.ToString("00");
        }
        else
        {
            GetComponent<Text>().text = "" + sec.ToString("00");
        }

        if (t <= 10f)
        {
            GameObject.Find("Main Camera Battle").GetComponent<AudioSource>().pitch = 1.2f;
        }
        else
        {
            GameObject.Find("Main Camera Battle").GetComponent<AudioSource>().pitch = 1;
        }

        if (t <= 0)
        {
            BattleManager.instance.GetComponent<EndGameManager>().currentPhase = EndGameManager.EndPhase.END;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void OnTimerEnd()
    {

    }
}
