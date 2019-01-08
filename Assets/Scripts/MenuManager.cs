using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject[] menus;

    public void Start()
    {
        for (int i= 0; i < menus.Length; i ++)
        {
            menus[i].SetActive(i == 0); 
        }
    }

    public void ChangeMenu(int menuID)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == menuID);
        }
    }

    public void RumbleMode()
    {
        GameManager.instance.gameMode = GameMode.RUMBLE;
    }

    public void ZoneMode()
    {
        GameManager.instance.gameMode = GameMode.ZONE;
    }
    public void CoinMode()
    {
        GameManager.instance.gameMode = GameMode.COIN;
    }

}
