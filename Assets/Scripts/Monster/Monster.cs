using Assets.Scripts.Monster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public MonsterList Species;
    public string Nickname;
    public MonsterType Type1;
    public MonsterType Type2;
    public int Level;
    public int CurrentHp;
    public int MaxHp { get { return GetCalculatedStat("HP", BaseStats.HP, EVs.HP, IVs.HP); } }
    public int Attack { get { return GetCalculatedStat("Attack", BaseStats.Attack, EVs.Attack, IVs.Attack); } }
    public int Defense { get { return GetCalculatedStat("Defense", BaseStats.Defense, EVs.Defense, IVs.Defense); } }
    public int SpecialAttack { get { return GetCalculatedStat("SpecialAttack", BaseStats.SpecialAttack, EVs.SpecialAttack, IVs.SpecialAttack); } }
    public int SpecialDefense { get { return GetCalculatedStat("SpecialDefense", BaseStats.SpecialDefense, EVs.SpecialDefense, IVs.SpecialDefense); } }
    public int Speed { get { return GetCalculatedStat("Speed", BaseStats.Speed, EVs.Speed, IVs.Speed); } }
    public MonsterNature Nature;
    public MonsterStats BaseStats;
    public MonsterEffortValues EVs;
    public MonsterIndividualValues IVs;
    public int ExperiencePoints;
    public MonsterMove Move1;
    public MonsterMove Move2;
    public MonsterMove Move3;
    public MonsterMove Move4;
    public Dictionary<int, MonsterMove> LearnSet;
    public GameObject CaptureObject;
    public Sprite Sprite;

    public void Initialize(Monster mon)
    {
        Species = mon.Species;
        Nickname = mon.Nickname;
        Type1 = mon.Type1;
        Type2 = mon.Type2;
        Level = mon.Level;
        CurrentHp = mon.CurrentHp;
        Nature = mon.Nature;
        BaseStats = mon.BaseStats;
        EVs = mon.EVs;
        IVs = mon.IVs;
        ExperiencePoints = mon.ExperiencePoints;
        Move1 = mon.Move1;
        Move2 = mon.Move2;
        Move3 = mon.Move3;
        Move4 = mon.Move4;
        LearnSet = mon.LearnSet;
        CaptureObject = mon.CaptureObject;
        Sprite = mon.Sprite;
    }
    public void LoadMonsterById(int id)
    {
        LoadMonsterBySpecies((MonsterList)id);
    }

    public int GetCalculatedStat(string statName, int baseStat, int ev, int iv)
    {
        int stat = ((2 * baseStat + iv + (ev / 4)) * Level) / 100;
        //I dont like doing it with 'statName' but I'm just making it work
        switch (statName)
        {
            case "HP":
                stat = stat + Level + 10;
                break;
            case "Attack":
                stat = stat + 5;
                if (MonsterNatureAdjustments.RaisesAttack(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 1.1));
                }
                else if (MonsterNatureAdjustments.LowersAttack(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 0.9));
                }
                break;
            case "Defense":
                stat = stat + 5;
                if (MonsterNatureAdjustments.RaisesDefense(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 1.1));
                }
                else if (MonsterNatureAdjustments.LowersDefense(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 0.9));
                }
                break;
            case "SpecialAttack":
                stat = stat + 5;
                if (MonsterNatureAdjustments.RaisesSpecialAttack(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 1.1));
                }
                else if (MonsterNatureAdjustments.LowersSpecialAttack(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 0.9));
                }
                break;
            case "SpecialDefense":
                stat = stat + 5;
                if (MonsterNatureAdjustments.RaisesSpecialDefense(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 1.1));
                }
                else if (MonsterNatureAdjustments.LowersSpecialDefense(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 0.9));
                }
                break;
            case "Speed":
                stat = stat + 5;
                if (MonsterNatureAdjustments.RaisesSpeed(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 1.1));
                }
                else if (MonsterNatureAdjustments.LowersSpeed(Nature))
                {
                    stat = System.Convert.ToInt32(System.Math.Floor(stat * 0.9));
                }
                break;
        }
        return stat;
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
                Nature = (MonsterNature)Random.Range(0, 25);
                BaseStats = new MonsterStats();
                BaseStats.HP = 45;
                BaseStats.Attack = 49;
                BaseStats.Defense = 49;
                BaseStats.SpecialAttack = 65;
                BaseStats.SpecialDefense = 65;
                BaseStats.Speed = 45;
                EVs = new MonsterEffortValues();
                IVs = new MonsterIndividualValues(true);
                ExperiencePoints = 0;
                CurrentHp = MaxHp;
                Move1 = new MonsterMove() { DisplayName = "Tackle", Type = MonsterType.Normal, Style = MoveStyle.Physical, BaseDamage = 40, BaseHitChance = 100 };
                Move2 = new MonsterMove() { DisplayName = "Growl", Type = MonsterType.Normal, Style = MoveStyle.Status, BaseDamage = 0, BaseHitChance = 100 };
                Move3 = new MonsterMove() { DisplayName = "Vine Whip", Type = MonsterType.Grass, Style = MoveStyle.Physical, BaseDamage = 45, BaseHitChance = 100 };
                Move4 = new MonsterMove() { DisplayName = "Poisonpowder", Type = MonsterType.Grass, Style = MoveStyle.Status, BaseDamage = 0, BaseHitChance = 75 };
                LearnSet = new Dictionary<int, MonsterMove>();
                CaptureObject = Resources.Load("Capture/greenmon_capture", typeof(GameObject)) as GameObject;
                Sprite = Resources.Load("Monster/greenmon", typeof(Sprite)) as Sprite;
                break;
            case MonsterList.Redmon:
                Species = MonsterList.Redmon;
                Nickname = "";
                Type1 = MonsterType.Fire;
                Type2 = MonsterType.None;
                Level = 1;
                Nature = (MonsterNature)Random.Range(0, 25);
                BaseStats = new MonsterStats();
                BaseStats.HP = 39;
                BaseStats.Attack = 52;
                BaseStats.Defense = 43;
                BaseStats.SpecialAttack = 60;
                BaseStats.SpecialDefense = 50;
                BaseStats.Speed = 65;
                EVs = new MonsterEffortValues();
                IVs = new MonsterIndividualValues(true);
                ExperiencePoints = 0;
                CurrentHp = MaxHp;
                Move1 = new MonsterMove() { DisplayName = "Scratch", Type = MonsterType.Normal, Style = MoveStyle.Physical, BaseDamage = 40, BaseHitChance = 100 };
                Move2 = new MonsterMove() { DisplayName = "Growl", Type = MonsterType.Normal, Style = MoveStyle.Status, BaseDamage = 0, BaseHitChance = 100 };
                Move3 = new MonsterMove() { DisplayName = "Ember", Type = MonsterType.Fire, Style = MoveStyle.Special, BaseDamage = 40, BaseHitChance = 100 };
                Move4 = new MonsterMove() { DisplayName = "Smokescreen", Type = MonsterType.Grass, Style = MoveStyle.Status, BaseDamage = 0, BaseHitChance = 100 };
                LearnSet = new Dictionary<int, MonsterMove>();
                CaptureObject = Resources.Load("Capture/redmon_capture", typeof(GameObject)) as GameObject;
                Sprite = Resources.Load("Monster/redmon", typeof(Sprite)) as Sprite;
                break;
            case MonsterList.Bluemon:
                Species = MonsterList.Bluemon;
                Nickname = "";
                Type1 = MonsterType.Water;
                Type2 = MonsterType.None;
                Level = 1;
                Nature = (MonsterNature)Random.Range(0, 25);
                BaseStats = new MonsterStats();
                BaseStats.HP = 44;
                BaseStats.Attack = 48;
                BaseStats.Defense = 65;
                BaseStats.SpecialAttack = 50;
                BaseStats.SpecialDefense = 64;
                BaseStats.Speed = 43;
                EVs = new MonsterEffortValues();
                IVs = new MonsterIndividualValues(true);
                ExperiencePoints = 0;
                CurrentHp = MaxHp;
                Move1 = new MonsterMove() { DisplayName = "Tackle", Type = MonsterType.Normal, Style = MoveStyle.Physical, BaseDamage = 40, BaseHitChance = 100 };
                Move2 = new MonsterMove() { DisplayName = "Tail Whip", Type = MonsterType.Normal, Style = MoveStyle.Status, BaseDamage = 0, BaseHitChance = 100 };
                Move3 = new MonsterMove() { DisplayName = "Water Gun", Type = MonsterType.Water, Style = MoveStyle.Special, BaseDamage = 40, BaseHitChance = 100 };
                Move4 = new MonsterMove() { DisplayName = "Withdraw", Type = MonsterType.Water, Style = MoveStyle.Status, BaseDamage = 0, BaseHitChance = 100 };
                LearnSet = new Dictionary<int, MonsterMove>();
                CaptureObject = Resources.Load("Capture/bluemon_capture", typeof(GameObject)) as GameObject;
                Sprite = Resources.Load("Monster/bluemon", typeof(Sprite)) as Sprite;
                break;
        }
    }
}
