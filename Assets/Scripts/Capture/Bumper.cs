using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public bool IsCircle;
    public Vector2 LaunchAngle;
    Animator Animator;

	// Use this for initialization
	void Start () {
        Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            Animator.Play("Lit");
            var rb = collision.transform.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.AddForce(LaunchAngle, ForceMode2D.Impulse);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsCircle)
        {
            Animator.Play("Lit");
        }
    }
}
