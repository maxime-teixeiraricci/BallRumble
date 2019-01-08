using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankDisplay : MonoBehaviour
{
    public PlayerControler pc;

	// Use this for initialization
	void Start ()
    {
        pc = transform.parent.GetComponent<PlayerControler>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (BattleManager.instance.GetComponent<EndGameManager>().currentPhase != EndGameManager.EndPhase.END)
        {
            GetComponent<Text>().enabled = false;
            return;
        }
        GetComponent<Text>().enabled = true;

		if (pc.rank == 1)
        {
            GetComponent<Text>().text = "1st";
            GetComponent<Text>().color = new Color(1f,0.7f, 0.1f);
            return;
        }
        if (pc.rank == 2)
        {
            GetComponent<Text>().text = "2nd";
            GetComponent<Text>().color = Color.grey;
            return;
        }
        if (pc.rank == 3)
        {
            GetComponent<Text>().text = "3rd";
            GetComponent<Text>().color = new Color(0.6f, 0.3f, 0);
            return;
        }
        else
        {
            GetComponent<Text>().text = pc.rank+"th";
            GetComponent<Text>().color = Color.white;
            return;
        }
    }
}
