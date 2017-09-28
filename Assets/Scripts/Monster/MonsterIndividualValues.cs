using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Monster
{
    public class MonsterIndividualValues
    {
        public int HP;
        public int Attack;
        public int SpecialAttack;
        public int Defense;
        public int SpecialDefense;
        public int Speed;

        public MonsterIndividualValues()
        {
            HP = 0;
            Attack = 0;
            SpecialAttack = 0;
            Defense = 0;
            SpecialDefense = 0;
            Speed = 0;
        }

        public MonsterIndividualValues(bool setRandomly)
        {
            if (setRandomly)
            {
                SetRandomIVs();
            }
        }

        public void SetRandomIVs()
        {
            var rand = new Random();
            HP = rand.Next(0, 31);
            Attack = rand.Next(0, 31);
            SpecialAttack = rand.Next(0, 31);
            Defense = rand.Next(0, 31);
            SpecialDefense = rand.Next(0, 31);
            Speed = rand.Next(0, 31);
        }
    }
}
