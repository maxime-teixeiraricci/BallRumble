using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int value;


    public void OnTriggerEnter(Collider other)
    {
      
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<RollingBall>().score += value;
            Destroy(gameObject);
        }
    }
}
