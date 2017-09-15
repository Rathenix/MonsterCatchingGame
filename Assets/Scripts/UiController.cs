using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour {

    public GoogleMap mainMap;
    public GameObject player;
    public GameObject TeamMenu;
    public MonsterInteractionsMenu monsterInteractionsMenu;

    private void Start()
    {
        ShowTeamText();
        monsterInteractionsMenu = FindObjectOfType<MonsterInteractionsMenu>();
        monsterInteractionsMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (monsterInteractionsMenu.monster != null)
        {
            var target = monsterInteractionsMenu.transform.FindChild("Target");
            target.transform.position = monsterInteractionsMenu.monster.transform.position;
        }
    }

    public void ShowTeamText()
    {
        var teamText = Instantiate(TeamMenu, new Vector3(-4.5f, .4f), new Quaternion(), transform.GetComponentInParent<Canvas>().transform).GetComponent<Text>();
        teamText.text = GameController.PlayerName + "'s Team\n";
        foreach (var mon in GameController.Team)
        {
            teamText.text += "\n" + mon.Name + "\n";
            teamText.text += "HP: " + mon.CurrentHp + "/" + mon.MaxHp + "\n";
            teamText.text += "Attack: " + mon.Attack + "\n";
            teamText.text += "Defense: " + mon.Defense + "\n";
            teamText.text += "Speed: " + mon.Speed + "\n";
        }
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
}
