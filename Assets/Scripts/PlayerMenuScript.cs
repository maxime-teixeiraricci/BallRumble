using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuScript : MonoBehaviour
{
    public GameObject[] playersIcon;
    [Header("Number Players Settings")]
    public Button addPlayerButton;
    public Button subPlayerButton;

    private GameManager gm;



	// Use this for initialization
	void Start ()
    {
        gm = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update ()
    {
		for (int i = 0; i < playersIcon.Length; i ++)
        {
            playersIcon[i].SetActive(i < gm.numberPlayer);
        }

        if (gm.numberPlayer == 2)
        {
            subPlayerButton.interactable = false;
            addPlayerButton.interactable = true;
        }
        else if(gm.numberPlayer == 8)
        {
            subPlayerButton.interactable = true;
            addPlayerButton.interactable = false;
        }
        else
        {
            subPlayerButton.interactable = true;
            addPlayerButton.interactable = true;
        }
    }


    public void AddPlayers()
    {
        gm.AddPlayer();
    }

    public void SubPlayers()
    {
        gm.SubPlayer();
    }


}
