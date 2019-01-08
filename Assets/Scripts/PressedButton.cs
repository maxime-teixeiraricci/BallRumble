using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PressedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image fillImage;
    public float timer;
    public float t;
    private bool fill;

    public UnityEngine.Events.UnityEvent OnFill;


    public void Update()
    {
        if (fillImage.fillAmount == 1)
        {
            BattleManager.instance.ExitGame();
        }
        if (fill)
        {
            t += Time.deltaTime;
            t = Mathf.Min(t, timer);
        }
        else
        {
            t -= 3*Time.deltaTime;
            t = Mathf.Max(t, 0);
        }
        fillImage.fillAmount = t / timer;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        fill = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        fill = false;
    }

}
