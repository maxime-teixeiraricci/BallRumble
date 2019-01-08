using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlane : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.gameObject.GetComponent<RollingBall>().lastTouched)
            {
                GameObject lastTouched = collision.gameObject.GetComponent<RollingBall>().lastTouched;
                if (GameManager.instance.gameMode == GameMode.RUMBLE) lastTouched.GetComponent<RollingBall>().score++;
                if(lastTouched.GetComponent<AIScript>())
                {
                    lastTouched.GetComponent<AIScript>().RandomOpponent();
                }
            }
            collision.transform.position = BattleManager.instance.NextSpawnPosition() ;
            collision.gameObject.GetComponent<RollingBall>().lastTouched = null;
            if (GameManager.instance.gameMode == GameMode.RUMBLE) collision.gameObject.GetComponent<RollingBall>().score --;
            collision.gameObject.GetComponent<RollingBall>().rg.velocity = Vector3.zero;
            
        }
        else
        {
            Destroy(collision.transform.gameObject);
        }
    }
}
