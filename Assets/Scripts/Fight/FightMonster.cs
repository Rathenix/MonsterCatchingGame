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
        var renderer = transform.GetComponent<SpriteRenderer>();
        renderer.sprite = Sprite;
        if (IsPlayer)
        {
            renderer.flipX = true;
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
            IVs.Attack, EVs.Attack, Defense, IVs.Defense, EVs.Defense, Speed, IVs.Speed, EVs.Speed, CurrentHp, MaxHp, IVs.HP, EVs.HP,
            SpecialAttack, IVs.SpecialAttack, EVs.SpecialAttack, SpecialDefense, IVs.SpecialDefense, EVs.SpecialDefense, Nature);
    }
}
