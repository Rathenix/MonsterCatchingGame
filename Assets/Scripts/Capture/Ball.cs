using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float MaxSpeed = 400f;
    public float RespawnTime = 1f;
    Vector3 StartPosition;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        StartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        if (transform.position.y < -220)
        {
            //balls--;
            rb.velocity = Vector2.zero;
            rb.inertia = 0;
            rb.rotation = 0;
            rb.simulated = false;
            transform.position = StartPosition;
            rb.simulated = true;
        }
	}
}
