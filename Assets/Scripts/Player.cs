using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GoogleMap mainMap;
    public GoogleMapLocation playerLoc;

	void Start () {
        mainMap.centerLocation = playerLoc;
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerLoc.latitude += 0.0001f;
            mainMap.centerLocation = playerLoc;
            mainMap.Refresh();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerLoc.latitude -= 0.0001f;
            mainMap.centerLocation = playerLoc;
            mainMap.Refresh();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerLoc.longitude += 0.0001f;
            mainMap.centerLocation = playerLoc;
            mainMap.Refresh();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerLoc.longitude -= 0.0001f;
            mainMap.centerLocation = playerLoc;
            mainMap.Refresh();
        }
    }
}
