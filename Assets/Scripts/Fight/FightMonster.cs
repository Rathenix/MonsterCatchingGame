using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightMonster : Monster {

    public bool IsPlayer;
    GameObject HealthBar;
    GameObject StatPane;

    private void Start()
    {
        if (IsPlayer)
        {
            transform.position = new Vector3(-70, 10, 0);
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        HealthBar = transform.FindChild("HealthBar").gameObject;
        var hpFillAmount = (float)CurrentHp / (float)MaxHp;
        HealthBar.GetComponent<Image>().fillAmount = hpFillAmount;
        SetStatPane();
    }

    void SetStatPane()
    {
        StatPane = transform.FindChild("StatPane").gameObject;
        var textbox = StatPane.GetComponent<TextMeshProUGUI>();
        textbox.text = System.String.Format(textbox.text, Species, Level, Type1, (Type2 == Assets.Scripts.Monster.MonsterType.None ? "" : " / " + Type2.ToString()), Attack,
            IVs.Attack, EVs.Attack, Defense, IVs.Defense, EVs.Defense, Speed, IVs.Speed, EVs.Speed);
        if (IsPlayer)
        {
            //StatPane.transform.position = new Vector3(-90, 20, 0);
            StatPane.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
}
