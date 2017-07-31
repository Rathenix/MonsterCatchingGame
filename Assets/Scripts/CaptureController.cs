using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaptureController : MonoBehaviour {

    public GameController Game;
    public GameObject[] CaptureMonsters;
    public Vector3 topBounds = new Vector3();
    public Vector3 bottomBounds = new Vector3();

    private void Start()
    {
        Game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        var monster = Game.EngagedMonster;
        var captureMonster = new GameObject();
        if (monster.Name == "Greenmon") //obviously, dont leave this like this
        {
            captureMonster = Instantiate(CaptureMonsters[0], new Vector3(), new Quaternion());
        }
        if (monster.Name == "Redmon")
        {
            captureMonster = Instantiate(CaptureMonsters[1], new Vector3(), new Quaternion());
        }
        if (monster.Name == "Bluemon")
        {
            captureMonster = Instantiate(CaptureMonsters[2], new Vector3(), new Quaternion());
        }
        captureMonster.GetComponent<CaptureMonster>().captureController = this;
    }
}
