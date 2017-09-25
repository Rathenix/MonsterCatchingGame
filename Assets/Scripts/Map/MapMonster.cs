using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMonster : Monster {

    public MonsterSpawner spawner;
    public UiController uiController;

    private void Update () {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            uiController.ShowMonsterInteractionsMenu(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        uiController.HideMonsterInteractionsMenu();
    }
    public void OnCapture()
    {
        Debug.Log("You try to capture the " + Species + ".");
        GameController.EngagedMonster = this;
        SceneManager.LoadScene("Capture");
    }
    public void OnFight()
    {
        Debug.Log("You try to fight the " + Species + ".");
        GameController.EngagedMonster = this;
        SceneManager.LoadScene("Fight");
    }
    public void OnScare()
    {
        Debug.Log("You try to scare the " + Species + ".");
        uiController.HideMonsterInteractionsMenu();
        Debug.Log("You scared it away!");
        spawner.activeSpawns -= 1;
        Destroy(gameObject);
    }
}
