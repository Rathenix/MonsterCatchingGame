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
        var captureMonster = new GameObject();
        if (engagedMonster.Name == "Greenmon") //obviously, dont leave this like this
        {
            captureMonster = Instantiate(CaptureMonsters[0], new Vector3(), new Quaternion());
        }
        if (engagedMonster.Name == "Redmon")
        {
            captureMonster = Instantiate(CaptureMonsters[1], new Vector3(), new Quaternion());
        }
        if (engagedMonster.Name == "Bluemon")
        {
            captureMonster = Instantiate(CaptureMonsters[2], new Vector3(), new Quaternion());
        }
        captureMonster.GetComponent<CaptureMonster>().captureController = this;
        captureMonster.GetComponent<Monster>().Initialize(engagedMonster);
    }

    public void MonsterCaptured(Monster monster)
    {
        GameController.Team.Add(monster);
        DontDestroyOnLoad(monster);
        SceneManager.LoadScene("Map");
    }
}
