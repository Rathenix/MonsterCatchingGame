using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManualMovement : MonoBehaviour {
    CharacterController controller;
    Vector2 moveDirection = Vector2.zero;
    public float Speed = 1f;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        OnTouchDetachFromDeviceAndMoveByDragging();
    }

    void OnTouchDetachFromDeviceAndMoveByDragging()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            GameManager.Instance.playerStatus = GameManager.PlayerStatus.FreeFromDevice;
            controller.Move(new Vector3(-touchDeltaPosition.x * Speed, -touchDeltaPosition.y * Speed, 0));
        }
    }
}
