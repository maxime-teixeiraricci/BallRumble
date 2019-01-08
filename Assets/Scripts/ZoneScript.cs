using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour
{
    public int ownerID;
    public RollingBall ownerScript;
    public float value;
    public SpriteRenderer sprite;

    public float t;

    public GameObject gaugeHud;

	// Use this for initialization
	void Start ()
    {
        gameObject.SetActive(GameManager.instance.gameMode == GameMode.ZONE);
        if (!(GameManager.instance.gameMode == GameMode.ZONE))
        {
            return;
        }
        Instantiate(gaugeHud, GameObject.Find("GaugeZone").transform).GetComponent<ZoneHUD>().zone = this ;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        value = Mathf.Min(100,value + 0.1f);
        t += Time.deltaTime;
        if (ownerID != -1 && t >= 0.75f)
        {
            if (BattleManager.instance.GetComponent<EndGameManager>().currentPhase != EndGameManager.EndPhase.END) 
            {
                ownerScript.score++;
            }
            t -= 0.75f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            RollingBall rb = other.gameObject.GetComponent<RollingBall>();
            if (ownerID != rb.playerId)
            {
                value -= 1;
                if (value <= 0 )
                {
                    t = 0;
                    ownerID = rb.playerId;
                    ownerScript = other.GetComponent<RollingBall>();
                    value = 100;
                    GetComponent<MeshRenderer>().material.color = GameManager.instance.playerColor[ownerID];
                    sprite.color = new Color(GameManager.instance.playerColor[ownerID].r, GameManager.instance.playerColor[ownerID].g, GameManager.instance.playerColor[ownerID].b, sprite.color.a);
                }
            }
            if (ownerID == rb.playerId)
            {
                value = Mathf.Min(100, value + 1.5f);
            }
        }
    }
}
