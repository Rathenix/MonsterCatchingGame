using Assets.Scripts.Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public MonsterList Species;
    public string Nickname = "";
    public MonsterType Type1 = MonsterType.None;
    public MonsterType Type2 = MonsterType.None;
    public int Level = 1;
    public int MaxHp = 1;
    public int CurrentHp = 1;
    public int Attack = 1;
    public int SpecialAttack = 1;
    public int Defense = 1;
    public int SpecialDefense = 1;
    public int Speed = 1;
    public MonsterEffortValues EVs;
    public MonsterIndividualValues IVs;
    public int ExperiencePoints;
    public MonsterMove Move1;
    public MonsterMove Move2;
    public MonsterMove Move3;
    public MonsterMove Move4;
    public Dictionary<int, MonsterMove> LearnSet;
    public GameObject CaptureObject;
    public GameObject FightObject;

    public void Initialize(Monster mon)
    {
        Species = mon.Species;
        Level = mon.Level;
        MaxHp = mon.MaxHp;
        CurrentHp = mon.CurrentHp;
        Attack = mon.Attack;
        Defense = mon.Defense;
        Speed = mon.Speed;
    }
    public void LoadMonsterById(int id)
    {
        LoadMonsterBySpecies((MonsterList)id);
    }
    
    public void LoadMonsterBySpecies(MonsterList species)
    {
        switch (species)
        {
            case MonsterList.Greenmon:
                Species = MonsterList.Greenmon;
                Nickname = "";
                Type1 = MonsterType.Grass;
                Type2 = MonsterType.Poison;
                Level = 1;
                MaxHp = 10;
                CurrentHp = 10;
                Attack = 5;
                SpecialAttack = 5;
                Defense = 5;
                SpecialDefense = 5;
                Speed = 5;
                EVs = new MonsterEffortValues();
                IVs = new MonsterIndividualValues();
                ExperiencePoints = 0;
                Move1 = new MonsterMove();
                Move2 = new MonsterMove();
                Move3 = new MonsterMove();
                Move4 = new MonsterMove();
                LearnSet = new Dictionary<int, MonsterMove>();
                CaptureObject = Resources.Load("Capture/greenmon_capture", typeof(GameObject)) as GameObject;
                FightObject = Resources.Load("Fight/greenmon_fight", typeof(GameObject)) as GameObject;
                break;
            case MonsterList.Redmon:
                Species = MonsterList.Redmon;
                Nickname = "";
                Type1 = MonsterType.Fire;
                Type2 = MonsterType.None;
                Level = 1;
                MaxHp = 10;
                CurrentHp = 10;
                Attack = 6;
                SpecialAttack = 5;
                Defense = 4;
                SpecialDefense = 5;
                Speed = 5;
                EVs = new MonsterEffortValues();
                IVs = new MonsterIndividualValues();
                ExperiencePoints = 0;
                Move1 = new MonsterMove();
                Move2 = new MonsterMove();
                Move3 = new MonsterMove();
                Move4 = new MonsterMove();
                LearnSet = new Dictionary<int, MonsterMove>();
                CaptureObject = Resources.Load("Capture/redmon_capture", typeof(GameObject)) as GameObject;
                FightObject = Resources.Load("Fight/redmon_fight", typeof(GameObject)) as GameObject;
                break;
            case MonsterList.Bluemon:
                Species = MonsterList.Bluemon;
                Nickname = "";
                Type1 = MonsterType.Water;
                Type2 = MonsterType.None;
                Level = 1;
                MaxHp = 10;
                CurrentHp = 10;
                Attack = 4;
                SpecialAttack = 5;
                Defense = 6;
                SpecialDefense = 5;
                Speed = 5;
                EVs = new MonsterEffortValues();
                IVs = new MonsterIndividualValues();
                ExperiencePoints = 0;
                Move1 = new MonsterMove();
                Move2 = new MonsterMove();
                Move3 = new MonsterMove();
                Move4 = new MonsterMove();
                LearnSet = new Dictionary<int, MonsterMove>();
                CaptureObject = Resources.Load("Capture/bluemon_capture", typeof(GameObject)) as GameObject;
                FightObject = Resources.Load("Fight/bluemon_fight", typeof(GameObject)) as GameObject;
                break;
        }
    }
}
