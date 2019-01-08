using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSScript : MonoBehaviour {

    float deltaTime = 0.0f;


    private void Start()
    {
        if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        GetComponent<Text>().text = fps.ToString("00");
        if (fps < 30f) GetComponent<Text>().color = Color.red;
        else if (fps < 60f) GetComponent<Text>().color = Color.yellow;
        else  GetComponent<Text>().color = Color.green;
    }
}
