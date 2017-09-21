using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaptureController : MonoBehaviour {

    public GameObject[] CaptureMonsters;
    public Vector3 topBounds = new Vector3();
    public Vector3 bottomBounds = new Vector3();


    private void Start()
    {
        var engagedMonster = GameController.EngagedMonster;
        var captureMonsterObj = new GameObject();
        if (engagedMonster.Name == "Greenmon") //obviously, dont leave this like this
        {
            captureMonsterObj = Instantiate(CaptureMonsters[0], new Vector3(-80, 100, 0), new Quaternion());
        }
        if (engagedMonster.Name == "Redmon")
        {
            captureMonsterObj = Instantiate(CaptureMonsters[1], new Vector3(-80, 100, 0), new Quaternion());
        }
        if (engagedMonster.Name == "Bluemon")
        {
            captureMonsterObj = Instantiate(CaptureMonsters[2], new Vector3(-80, 100, 0), new Quaternion());
        }
        var captureMonster = captureMonsterObj.GetComponent<CaptureMonster>();
        captureMonster.captureController = this;
        captureMonster.Initialize(engagedMonster);
    }

    public void MonsterCaptured(Monster monster)
    {
        GameController.Team.Add(monster);
        SceneManager.LoadScene("Map");
    }
}
