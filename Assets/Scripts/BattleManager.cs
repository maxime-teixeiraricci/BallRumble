using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public GameManager gm;
    public Image[] playersControler;
    public GameObject[] players;
    public Transform[] spawnsPosition;
    public float time;


    [Header("Zone Mode Object")]
    public GameObject[] zones;

    [Header("Coin Mode Object")]
    public GameObject[] coinGenerator;

    public int indexSpawn;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start ()
    {
        gm = GameManager.instance;
        time = gm.timeGame;
        int numberPlayer = gm.numberPlayer;
        for (int i = 0; i < 8; i ++)
        {
            players[i].SetActive(i < numberPlayer);
            if (i < numberPlayer)
            {
                players[i].transform.position = NextSpawnPosition();
            }
            playersControler[i].gameObject.SetActive(i < numberPlayer);
        }
        
	}


    void Update()
    {
        time -= Time.deltaTime;
    }



    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ShuffleSpawnPosition()
    {
        for (int i = 0; i < spawnsPosition.Length; i ++)
        {
            int r = Random.Range(0, spawnsPosition.Length);
            Transform t = spawnsPosition[i];
            spawnsPosition[i] = spawnsPosition[r];
            spawnsPosition[r] = t;
        }
    }

    public Vector3 NextSpawnPosition()
    {
        indexSpawn = indexSpawn % spawnsPosition.Length;
        if (indexSpawn == 0)
        {
            ShuffleSpawnPosition();
        }
        print(indexSpawn);
        return spawnsPosition[indexSpawn++].position;
    }


}
