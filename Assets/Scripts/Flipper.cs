using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
    public KeyCode key;
    public GameObject button;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKey(key))
        {
            var angle = 45;
            if(key == KeyCode.RightArrow)
            {
                angle *= -1;
            }
            GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                if (hitInfo)
                {
                    if (hitInfo.transform == button.transform)
                    {
                        var angle = 45;
                        if (key == KeyCode.RightArrow)
                        {
                            angle *= -1;
                        }
                        GetComponent<Rigidbody2D>().MoveRotation(angle);
                    }
                }
            }
        }
    }
}
