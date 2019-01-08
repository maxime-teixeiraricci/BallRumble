using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using System;

public class PlayerControler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Player Stats")]
    public int playerId;
    public int rank;
   // public float speed;

    [Header("Script Necessary")]
    public Text text;
    public Text scoreTitle;
    public Vector2 movement;
    public float deltaMagnitude;

    public bool isMoving;
    public Vector2 startVect;
    public Vector2 currentVect;
    public enum MovePhase { START, MOVE};
    public MovePhase currentPhase;

    public int touchID;
    public GameObject target;


    public void Start()
    {
        target = BattleManager.instance.players[playerId];
        switch (GameManager.instance.gameMode)
        {
            case (GameMode.COIN):
                scoreTitle.text = "COINS";
                break;

            case (GameMode.RUMBLE):
                scoreTitle.text = "SCORE";
                break;
            case (GameMode.ZONE):
                scoreTitle.text = "POINTS";
                break;
        }
    }
    public void FixedUpdate()
    {
        if (isMoving) Move();
        else movement = Vector2.zero;
        target.GetComponent<RollingBall>().inputVector = movement;
        rank = Rank();
    }


    void Move()
    {
        Vector2 mov = currentVect - startVect;
        print("Magnitude : " + mov.magnitude);
        if (mov.magnitude >= deltaMagnitude)
        {
            movement = mov.normalized;
        }
        else
        {
            movement = mov / deltaMagnitude;
        }

    }

    public void OnBeginDrag(PointerEventData data)
    {
        isMoving = true;
        startVect = data.position;
        target.GetComponent<Rigidbody>().velocity = Vector2.zero;
    }

    public void OnDrag(PointerEventData data)
    {
        currentVect = data.position;
        
    }

    public void OnEndDrag(PointerEventData data)
    {
        isMoving = false;
        Debug.Log("OnEndDrag: " + data.position);
    }

    public int Rank()
    {
        int rank = 1;
        foreach (GameObject player in BattleManager.instance.players)
        {
            if (player.GetComponent<RollingBall>().score > target.GetComponent<RollingBall>().score && player.activeSelf)
            {
                rank++;
            }
        }
        return rank;
    }
}
 