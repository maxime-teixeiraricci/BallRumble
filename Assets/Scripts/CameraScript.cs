using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 destination;
    public float speed;
    public float maxZoom;
    public float minZoom;
    public float zoomFactor;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate()
    {
       if (target)
        {
            UpdateTarget();
            return;
        }
       // UpdateAverage();
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(maxZoom, minZoom, BoundingBox()/ zoomFactor);

    }

    float BoundingBox()
    {
        Bounds bb = new Bounds(BattleManager.instance.players[0].transform.position, Vector3.zero);
        foreach (GameObject player in BattleManager.instance.players)
        {
            if (player.activeSelf)
            {
                print(player);
                bb.Encapsulate(player.transform.position);
            }
        }
        destination = bb.center ;
        Vector3 vect = (destination + offset) - transform.position;
        transform.position += vect * speed * Time.deltaTime ;
        return Mathf.Max(bb.size.x, Mathf.Max(bb.size.y, bb.size.z));
    }

    void UpdateAverage()
    {
        float x = 0;
        float z = 0;
        GameObject[] listPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in listPlayers)
        {
            x += go.transform.position.x / listPlayers.Length;
            z += go.transform.position.z / listPlayers.Length;
        }
        destination = new Vector3(x, 0, z) + offset;


        
    }

    void UpdateTarget()
    {
  
        Vector3 vect = target.transform.position - transform.position;
        transform.position += (vect + offset) * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(destination, Vector3.one);
    }
}
