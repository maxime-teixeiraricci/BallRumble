using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public float speed;
    public float timer;
	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        transform.eulerAngles = new Vector3(0, Time.deltaTime * speed, 0) + transform.eulerAngles;
        if (timer > 5) return;

        if (timer < 0f)
        {
            Destroy(gameObject);
        }
        else if (timer < 2f)
        {
            GetComponent<MeshRenderer>().enabled = (timer % 0.25f) < 0.125f;
        }
        else if (timer < 5f)
        {
            GetComponent<MeshRenderer>().enabled = (timer % 0.5f) < 0.25f;
        }
    }
}
