using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public Vector2 LaunchAngle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            var rb = collision.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(LaunchAngle, ForceMode2D.Impulse);
        }
        
    }
}
