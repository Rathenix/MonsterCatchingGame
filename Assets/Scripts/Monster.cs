using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public string Name = "Monster";
    public int Level = 1;
    public int MaxHp = 1;
    public int CurrentHp = 1;
    public int Attack = 1;
    public int Defense = 1;
    public int Speed = 1;

    public void Initialize(Monster mon)
    {
        Name = mon.Name;
        Level = mon.Level;
        MaxHp = mon.MaxHp;
        CurrentHp = mon.CurrentHp;
        Attack = mon.Attack;
        Defense = mon.Defense;
        Speed = mon.Speed;
    }
    public void SetMonsterStatsById(int id)
    {
        switch(id) //obviously, dont leave this like this
        {
            case 0:
                Name = "Greenmon";
                Level = 1;
                MaxHp = 10;
                CurrentHp = 10;
                Attack = 5;
                Defense = 5;
                Speed = 5;
                break;
            case 1:
                Name = "Redmon";
                Level = 1;
                MaxHp = 10;
                CurrentHp = 10;
                Attack = 6;
                Defense = 4;
                Speed = 5;
                break;
            case 2:
                Name = "Bluemon";
                Level = 1;
                MaxHp = 10;
                CurrentHp = 10;
                Attack = 4;
                Defense = 6;
                Speed = 5;
                break;
        }
    }

}
