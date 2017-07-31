using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInteractionsMenu : MonoBehaviour {
    public Button captureButton;
    public Button fightButton;
    public Button scareButton;
    public MapMonster monster;

    private void Start()
    {
        captureButton.onClick.AddListener(OnClickCapture);
        fightButton.onClick.AddListener(OnClickFight);
        scareButton.onClick.AddListener(OnClickScare);
    }
    private void OnClickCapture()
    {
        monster.OnCapture();
    }
    private void OnClickFight()
    {
        monster.OnFight();
    }
    private void OnClickScare()
    {
        monster.OnScare();
    }
}
