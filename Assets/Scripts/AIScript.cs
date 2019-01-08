using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour {

    public Rigidbody rg;
    public float speed = 5;
    public GameObject target;


	// Use this for initialization
	void Start ()
    {
        RandomOpponent();
       // speed = 2f;
        rg = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        DontFall();
        Vector3 res = Vector3.zero;
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (ball != gameObject)
            {
                Vector3 vect = ball.transform.position - transform.position;
                int k = (target == ball) ? 15 : 1;
                res = res + (1f / (vect.magnitude * vect.magnitude)) * vect * k * Random.Range(0.85f,1.15f);
            }
        }
        //rg.AddForce(res.normalized * speed);
        
    }

    public void RandomOpponent()
    {
        GameObject[] opponents = GameObject.FindGameObjectsWithTag("Player");
        GameObject opponent;
        do
        {
            opponent = opponents[Random.Range(0, opponents.Length)];
        } while (opponent == gameObject);
        target = opponent;
    }

    void DontFall()
    {
        Vector3 vectMove = Vector3.zero;
        int nbRay = 36;
        for(int i = 0;i < nbRay; i++)
        {
            float a = 360f / nbRay * i * Mathf.Deg2Rad;
            float d = 0.75f;
            Vector3 vect = new Vector3(transform.position.x + d * Mathf.Cos(a), transform.position.y+1, transform.position.z + d * Mathf.Sin(a));
            Ray ray = new Ray(vect, Vector3.down);
            

            RaycastHit hit;
            if (!Physics.Raycast(ray.origin, ray.direction, out hit, 2))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                vectMove += transform.position - ray.origin;
            }
            else
            {
                if (hit.transform.tag == "Block")
                {
                    Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
                    vectMove += (transform.position - ray.origin);
                }
                else if (hit.transform.tag == "Player" && hit.transform.gameObject != gameObject)
                {
                    Debug.DrawRay(ray.origin, ray.direction, Color.blue);
                    vectMove += (transform.position - ray.origin);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction, Color.green);
                }
                    
            }
        }
        print(vectMove);
        if (vectMove.magnitude < 1)
        {
            rg.AddForce(vectMove * speed );
            return;
        }
        rg.AddForce(vectMove.normalized * speed );
    }
    
}
