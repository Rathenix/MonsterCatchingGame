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
            transform.position = StartPosition;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}
}
