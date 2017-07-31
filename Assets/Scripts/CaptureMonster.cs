using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureMonster : MonoBehaviour {

    public Monster Monster;
    public CaptureController captureController;
    private float moveTime;
    public float moveDistance = 1f;
    public float moveCooldown = 1f;
    public float restChance = 0f;
    public float restTime = 1f;

    private void Start()
    {
        moveDistance = 1f / Monster.Speed;
        moveCooldown = 1f / Monster.Speed;
        restChance = 100f - ((Monster.CurrentHp / Monster.MaxHp) * 100f);
        restTime = 10 - Monster.Speed;
    }
    private void Update()
    {
        if (Time.time >= moveTime + moveCooldown)
        {
            var randDirection = Random.Range(0, 4);
            switch (randDirection)
            {
                case 0:
                    if (transform.position.x <= captureController.bottomBounds.x)
                    {
                        transform.position += new Vector3(moveDistance, 0, 0);
                        if (transform.position.x >= captureController.bottomBounds.x)
                        {
                            transform.position = new Vector3(captureController.bottomBounds.x, transform.position.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 1:
                    if (transform.position.x >= captureController.topBounds.x)
                    {
                        transform.position += new Vector3(-moveDistance, 0, 0);
                        if (transform.position.x <= captureController.topBounds.x)
                        {
                            transform.position = new Vector3(captureController.topBounds.x, transform.position.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 2:
                    if (transform.position.y <= captureController.topBounds.y)
                    {
                        transform.position += new Vector3(0, moveDistance, 0);
                        if (transform.position.y >= captureController.topBounds.y)
                        {
                            transform.position = new Vector3(transform.position.x, captureController.topBounds.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 3:
                    if (transform.position.y >= captureController.bottomBounds.y)
                    {
                        transform.position += new Vector3(0, -moveDistance, 0);
                        if (transform.position.y <= captureController.bottomBounds.y)
                        {
                            transform.position = new Vector3(transform.position.x, captureController.bottomBounds.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var collider = Physics2D.OverlapPoint(mousePosition);
            if (collider)
            {
                Debug.Log("Got him!");
            }
        }
    }
}
