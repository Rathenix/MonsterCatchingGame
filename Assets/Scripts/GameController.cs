using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{
    public static string PlayerName = "Player";
    public static List<Monster> Team = new List<Monster>();
    public static int PlayerCaptureBalls = 10;
    public static int PlayerChips = 0;
    public static Monster EngagedMonster;
}
