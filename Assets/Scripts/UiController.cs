using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour {

    public GameObject hamburgerMenu;
    public MonsterInteractionsMenu monsterInteractionsMenu;
    public GameObject TeamEntry;

    private void Start()
    {
        monsterInteractionsMenu.gameObject.SetActive(false);
        LoadHambugerAndSetTeamText();
    }

    private void Update()
    {
        if (monsterInteractionsMenu.monster != null)
        {
            var target = monsterInteractionsMenu.transform.FindChild("Target");
            target.transform.position = monsterInteractionsMenu.monster.transform.position;
        }
    }

    public void LoadHambugerAndSetTeamText()
    {
        var teamPane = hamburgerMenu.transform.FindChild("TeamPane");
        //var teamText = teamPane.GetComponentInChildren<TextMeshProUGUI>();
        //teamText.text = GameController.PlayerName + "'s Team\n";
        //foreach (var mon in GameController.Team)
        //{
        //    teamText.text += "\n" + mon.Name + "\n";
        //    teamText.text += "HP: " + mon.CurrentHp + "/" + mon.MaxHp + "\n";
        //    teamText.text += "Attack: " + mon.Attack + "\n";
        //    teamText.text += "Defense: " + mon.Defense + "\n";
        //    teamText.text += "Speed: " + mon.Speed + "\n";
        //}
        for (var mon = 0; mon < GameController.Team.Count; mon++)
        {
            var monster = GameController.Team[mon];
            var teamPadding = 35f * mon;
            var entry = Instantiate(TeamEntry, teamPane);
            entry.transform.localPosition = new Vector3(-3, 115 - teamPadding, 0);
            entry.transform.FindChild("EntryName").GetComponent<TextMeshProUGUI>().text = monster.Name;
            entry.transform.FindChild("HPAmount").GetComponent<TextMeshProUGUI>().text = monster.CurrentHp + "/" + monster.MaxHp;
            var hpFillAmount = (float)monster.CurrentHp / (float)monster.MaxHp;
            Debug.Log("Calculated fill amount = " + hpFillAmount);
            entry.transform.FindChild("HealthBar").GetComponent<Image>().fillAmount = hpFillAmount;
            Debug.Log("HP fill updated. Current value = " + entry.transform.FindChild("HealthBar").GetComponent<Image>().fillAmount);
            var statText = entry.transform.FindChild("Stats").GetComponent<TextMeshProUGUI>().text;
            entry.transform.FindChild("Stats").GetComponent<TextMeshProUGUI>().text = String.Format(statText, monster.Attack, monster.Defense, monster.Speed);
        }

        teamPane.gameObject.SetActive(false);
        var button = hamburgerMenu.GetComponentInChildren<Button>();
        button.onClick.AddListener(OnHamburgerClick);
    }

    public MonsterInteractionsMenu ShowMonsterInteractionsMenu(MapMonster monster)
    {
        monsterInteractionsMenu.gameObject.SetActive(true);
        monsterInteractionsMenu.monster = monster;
        var target = monsterInteractionsMenu.transform.FindChild("Target");
        target.transform.position = monster.transform.position;
        return monsterInteractionsMenu;
    }

    public void HideMonsterInteractionsMenu()
    {
        monsterInteractionsMenu.monster = null;
        monsterInteractionsMenu.gameObject.SetActive(false);
    }

    void OnHamburgerClick()
    {
        var teamPane = hamburgerMenu.transform.FindChild("TeamPane");
        teamPane.gameObject.SetActive(!teamPane.gameObject.activeSelf);
    }
}
