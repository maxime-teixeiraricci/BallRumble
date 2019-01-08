using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingTimeScript : MonoBehaviour
{
    

	// Use this for initialization
	void Start ()
    {
        GetComponent<Text>().text = (GameManager.instance.timeGame / 60).ToString("00") + ":" + (GameManager.instance.timeGame % 60).ToString("00");

    }
	

    public void AddMinute()
    {
        GameManager.instance.timeGame += 60;
        GameManager.instance.timeGame = Mathf.Min(GameManager.instance.timeGame, 60 * 99);
        GetComponent<Text>().text = (GameManager.instance.timeGame / 60).ToString("00") + ":" + (GameManager.instance.timeGame % 60).ToString("00");
    }

    public void SubMinute()
    {
        GameManager.instance.timeGame -= 60;
        GameManager.instance.timeGame = Mathf.Max(GameManager.instance.timeGame, 60);
        GetComponent<Text>().text = (GameManager.instance.timeGame / 60).ToString("00") + ":" + (GameManager.instance.timeGame % 60).ToString("00");
    }
}
