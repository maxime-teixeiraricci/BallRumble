using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{

    public enum EndPhase { GAME, END}
    public EndPhase currentPhase;
    public float endTime;
    
	
	// Update is called once per frame
	void Update ()
    {
        
		if (EndPhase.END == currentPhase)
        {
            Time.timeScale = 0.35f;
            endTime -= Time.deltaTime;
            if (endTime <= 0)
            {
                BattleManager.instance.ExitGame();
            }
        }
	}
}
