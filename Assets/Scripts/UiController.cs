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
    public GameObject Overlay;
    bool recoveryEngaged = false;

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
        for (var mon = 0; mon < GameController.Team.Count; mon++)
        {
            var monster = GameController.Team[mon];
            var teamPadding = 42f * mon;
            var entryObj = Instantiate(TeamEntry, teamPane);
            entryObj.transform.localPosition = new Vector3(0, 120 - teamPadding, 0);
            var entry = entryObj.GetComponent<TeamEntry>();
            entry.Monster = monster;
        }

        teamPane.gameObject.SetActive(false);
        var hamburgerButton = hamburgerMenu.GetComponentInChildren<Button>();
        hamburgerButton.onClick.AddListener(OnHamburgerClick);
        var recoverButton = teamPane.GetComponentInChildren<Button>();
        recoverButton.onClick.AddListener(OnRecoverClick);
        var ChipsText = teamPane.transform.FindChild("ChipsText");
        ChipsText.GetComponent<TextMeshProUGUI>().text = "Chips: " + GameController.PlayerChips;
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
        Overlay.SetActive(!Overlay.activeSelf);
    }

    void OnRecoverClick()
    {
        var entries = FindObjectsOfType<TeamEntry>();
        foreach (var entry in entries)
        {
            if (entry.Monster.CurrentHp < entry.Monster.MaxHp)
            {
                var button = entry.GetComponent<Button>();
                button.enabled = true;
;            }
        }
    }
}
