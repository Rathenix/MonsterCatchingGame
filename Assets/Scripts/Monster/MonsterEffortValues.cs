﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Monster
{
    public class MonsterEffortValues
    {
        public int HP;
        public int Attack;
        public int SpecialAttack;
        public int Defense;
        public int SpecialDefense;
        public int Speed;

        public MonsterEffortValues()
        {
            HP = 0;
            Attack = 0;
            SpecialAttack = 0;
            Defense = 0;
            SpecialDefense = 0;
            Speed = 0;
        }
    }
}
