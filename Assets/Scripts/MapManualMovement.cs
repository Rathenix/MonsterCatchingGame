using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManualMovement : MonoBehaviour {
    Vector2 moveDirection = Vector2.zero;
    float timeSinceLastTouchMove = 0f;
    float delayBeforeReattaching = 3f;
    public float Speed = 1f;
	
	void Update () {
        OnTouchDetachFromDeviceAndMoveByDragging();
        ReattachToDeviceIfNotMovedRecently();
    }

    void OnTouchDetachFromDeviceAndMoveByDragging()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            GoMapGameManager.Instance.playerStatus = GoMapGameManager.PlayerStatus.FreeFromDevice;
            timeSinceLastTouchMove = 0f;
            transform.position += new Vector3(-touchDeltaPosition.x * Speed, -touchDeltaPosition.y * Speed, 0);
        }
        else
        {
            timeSinceLastTouchMove += Time.deltaTime;
        }
    }

    void ReattachToDeviceIfNotMovedRecently()
    {
        if (timeSinceLastTouchMove >= delayBeforeReattaching)
        {
            GoMapGameManager.Instance.playerStatus = GoMapGameManager.PlayerStatus.TiedToDevice;
        }
    }
}
