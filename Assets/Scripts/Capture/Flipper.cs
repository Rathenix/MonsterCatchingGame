using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
    public GameObject LeftFlipper;
    public GameObject RightFlipper;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject BothButton;

    private void Start()
    {
    }
    private void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                if (hitInfo)
                {
                    if (hitInfo.transform == LeftButton.transform)
                    {
                        var angle = LeftFlipper.GetComponent<HingeJoint2D>().limits.max;
                        LeftFlipper.GetComponent<Rigidbody2D>().MoveRotation(-angle);
                    }
                    else if (hitInfo.transform == RightButton.transform)
                    {
                        var angle = RightFlipper.GetComponent<HingeJoint2D>().limits.max;
                        RightFlipper.GetComponent<Rigidbody2D>().MoveRotation(-angle);
                    }
                    else if (hitInfo.transform == BothButton.transform)
                    {
                        var lAngle = LeftFlipper.GetComponent<HingeJoint2D>().limits.max;
                        var rAngle = RightFlipper.GetComponent<HingeJoint2D>().limits.max;
                        LeftFlipper.GetComponent<Rigidbody2D>().MoveRotation(-lAngle);
                        RightFlipper.GetComponent<Rigidbody2D>().MoveRotation(-rAngle);
                    }
                }
            }
        }
    }
}
