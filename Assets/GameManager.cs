using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameMode gameMode;
    public int numberPlayer;
    public float timeGame;

    public Color[] playerColor;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    
    public void AddPlayer()
    {
        numberPlayer++;
    }

    public void SubPlayer()
    {
        numberPlayer--;
    }



    public void RumbleMode()
    {
        gameMode = GameMode.RUMBLE;
    }

    public void ZoneMode()
    {
        gameMode = GameMode.ZONE;
    }
    public void CoinMode()
    {
        gameMode = GameMode.COIN;
    }

}
public enum GameMode { RUMBLE, ZONE, COIN }