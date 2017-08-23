using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMonster : Monster {

    public GoogleMap mainMap;
    public MonsterSpawner spawner;
    public float lastLatCenter;
    public float lastLonCenter;
    public UiController uiController;
    public MonsterInteractionsMenu interactionsMenu;
    public bool hasInteractionsMenu = false;

    private void Update () {
        if (mainMap.mapLoaded)
        {
            if (mainMap.centerLocation.latitude > lastLatCenter)
            {
                transform.position -= new Vector3(0, mainMap.Y_PER_0P0001_LAT, 0);
                if (hasInteractionsMenu)
                {
                    interactionsMenu.transform.position -= new Vector3(0, mainMap.Y_PER_0P0001_LAT, 0);
                }                
            }
            if (mainMap.centerLocation.latitude < lastLatCenter)
            {
                transform.position += new Vector3(0, mainMap.Y_PER_0P0001_LAT, 0);
                if (hasInteractionsMenu)
                {
                    interactionsMenu.transform.position += new Vector3(0, mainMap.Y_PER_0P0001_LAT, 0);
                }
            }
            if (mainMap.centerLocation.longitude > lastLonCenter)
            {
                transform.position -= new Vector3(mainMap.X_PER_0P0001_LON, 0, 0);
                if (hasInteractionsMenu)
                {
                    interactionsMenu.transform.position -= new Vector3(mainMap.X_PER_0P0001_LON, 0, 0);
                }
            }
            if (mainMap.centerLocation.longitude < lastLonCenter)
            {
                transform.position += new Vector3(mainMap.X_PER_0P0001_LON, 0, 0);
                if (hasInteractionsMenu)
                {
                    interactionsMenu.transform.position += new Vector3(mainMap.X_PER_0P0001_LON, 0, 0);
                }
            }
            lastLatCenter = mainMap.centerLocation.latitude;
            lastLonCenter = mainMap.centerLocation.longitude;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactionsMenu = uiController.ShowMonsterInteractionsMenu(gameObject);
            interactionsMenu.monster = this;
            hasInteractionsMenu = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetRidOfInteractionsMenu();
    }
    public void OnCapture()
    {
        Debug.Log("You try to capture it.");
        GameController.EngagedMonster = this;
        SceneManager.LoadScene("Capture");
    }
    public void OnFight()
    {
        Debug.Log("You try to fight it.");
        GameController.EngagedMonster = this;
        SceneManager.LoadScene("Fight");
    }
    public void OnScare()
    {
        Debug.Log("You try to scare it.");
        GetRidOfInteractionsMenu();
        Debug.Log("You scared it away!");
        spawner.activeSpawns -= 1;
        Destroy(gameObject);
    }
    private void GetRidOfInteractionsMenu()
    {
        interactionsMenu.transform.SetParent(transform);
        Destroy(interactionsMenu);
        hasInteractionsMenu = false;
    }
}
