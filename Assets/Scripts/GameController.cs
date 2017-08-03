using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string PlayerName = "Player";
    public List<Monster> Team;
    public int PlayerCaptureBalls = 10;
    public Monster EngagedMonster;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Team = new List<Monster>();
    }
}
