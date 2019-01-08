using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public float radius;

    public CoinStruct[] coins;

    public float time;
    public int number;

    private float t;
    private int rarityTotal;


    private void Start()
    {
        gameObject.SetActive(GameManager.instance.gameMode == GameMode.COIN);
        foreach (CoinStruct c in coins)
        {
            rarityTotal += c.rarity;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        t += Time.deltaTime;
        if (t >= time)
        {
            for (int i = 0; i < number; i ++)
            {
                CreateCoin();
            }
            t -= time;
        }
	}


    void CreateCoin()
    {
        int r = Random.Range(0, rarityTotal);
        foreach (CoinStruct c in coins)
        {
            r -= c.rarity;
            if ( r < 0)
            {
                float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
                float distance = Random.Range(0f, radius);
                GameObject coin = Instantiate(c.objectCoin);
                coin.transform.position = transform.position + new Vector3(distance * Mathf.Cos(angle), 0, distance * Mathf.Sin(angle));
                return;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

[System.Serializable]
public struct CoinStruct
{
    public GameObject objectCoin;
    public int rarity;
}
