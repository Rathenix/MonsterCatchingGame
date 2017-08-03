﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour {

    public GameController Game;
    public GoogleMap mainMap;
    public GameObject player;
    public GameObject TeamMenu;
    public MonsterInteractionsMenu monsterInteractionsMenu;

    private void Start()
    {
        Game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ShowTeamText();
    }

    public void ShowTeamText()
    {
        var teamText = Instantiate(TeamMenu, new Vector3(-4.5f, .4f), new Quaternion(), transform.GetComponentInParent<Canvas>().transform).GetComponent<Text>();
        teamText.text = Game.PlayerName + "'s Team\n";
        foreach (var mon in Game.Team)
        {
            teamText.text += "\n" + mon.Name + "\n";
            teamText.text += "HP: " + mon.CurrentHp + "/" + mon.MaxHp + "\n";
            teamText.text += "Attack: " + mon.Attack + "\n";
            teamText.text += "Defense: " + mon.Defense + "\n";
            teamText.text += "Speed: " + mon.Speed + "\n";
        }
    }

    public MonsterInteractionsMenu ShowMonsterInteractionsMenu(GameObject target)
    {
        return Instantiate(monsterInteractionsMenu, target.transform.position, new Quaternion(), transform.GetComponentInParent<Canvas>().transform);
    }
}
