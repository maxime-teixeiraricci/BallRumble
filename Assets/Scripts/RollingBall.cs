using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    public int playerId;
    public float ballSpeed;
    public GameObject lastTouched;
    public Rigidbody rg;
    public float speed = 1;
    public int score = 0;
    public Vector2 inputVector;
    public CursorScript cursor;

	// Use this for initialization
	void Start ()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(inputVector.x, 0.0f, inputVector.y);

        
        ballSpeed = rg.velocity.magnitude;
        if (rg.velocity.magnitude > speed)
        {
            rg.velocity = rg.velocity / rg.velocity.magnitude * speed;
        }
        rg.AddForce(movement * speed);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            lastTouched = collision.transform.gameObject;
        }
    }
}
