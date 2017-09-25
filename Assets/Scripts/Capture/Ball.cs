using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    Vector3 StartPosition;

	// Use this for initialization
	void Start () {
        StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -200)
        {
            //balls--;
            var rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.rotation = 0;
            rb.inertia = 0;
            rb.Sleep();
            transform.position = StartPosition;
        }
	}
}
