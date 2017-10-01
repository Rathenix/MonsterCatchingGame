using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Monster
{
    public enum MonsterNature
    {
        Hardy,
        Lonely,
        Brave,
        Adamant,
        Naughty,
        Bold,
        Docile,
        Relaxed,
        Impish,
        Lax,
        Timid,
        Hasty,
        Serious,
        Jolly,
        Naive,
        Modest,
        Mild,
        Quiet,
        Bashful,
        Rash,
        Calm,
        Gentle,
        Sassy,
        Careful,
        Quirky
    }

    public static class MonsterNatureAdjustments
    {
        public static bool RaisesAttack(MonsterNature nature)
        {
            return nature == MonsterNature.Lonely ||
                nature == MonsterNature.Adamant ||
                nature == MonsterNature.Naughty ||
                nature == MonsterNature.Brave;
        }
        public static bool RaisesDefense(MonsterNature nature)
        {
            return nature == MonsterNature.Bold ||
                nature == MonsterNature.Relaxed ||
                nature == MonsterNature.Impish ||
                nature == MonsterNature.Lax;
        }
        public static bool RaisesSpecialAttack(MonsterNature nature)
        {
            return nature == MonsterNature.Modest ||
                nature == MonsterNature.Mild ||
                nature == MonsterNature.Quiet ||
                nature == MonsterNature.Rash;
        }
        public static bool RaisesSpecialDefense(MonsterNature nature)
        {
            return nature == MonsterNature.Calm ||
                nature == MonsterNature.Gentle ||
                nature == MonsterNature.Sassy ||
                nature == MonsterNature.Careful;
        }
        public static bool RaisesSpeed(MonsterNature nature)
        {
            return nature == MonsterNature.Timid ||
                nature == MonsterNature.Hasty ||
                nature == MonsterNature.Jolly ||
                nature == MonsterNature.Naive;
        }
        public static bool LowersAttack(MonsterNature nature)
        {
            return nature == MonsterNature.Bold ||
                nature == MonsterNature.Timid ||
                nature == MonsterNature.Modest ||
                nature == MonsterNature.Calm;
        }
        public static bool LowersDefense(MonsterNature nature)
        {
            return nature == MonsterNature.Lonely ||
                nature == MonsterNature.Hasty ||
                nature == MonsterNature.Mild ||
                nature == MonsterNature.Gentle;
        }
        public static bool LowersSpecialAttack(MonsterNature nature)
        {
            return nature == MonsterNature.Adamant ||
                nature == MonsterNature.Impish ||
                nature == MonsterNature.Jolly ||
                nature == MonsterNature.Careful;
        }
        public static bool LowersSpecialDefense(MonsterNature nature)
        {
            return nature == MonsterNature.Naughty ||
                nature == MonsterNature.Lax ||
                nature == MonsterNature.Naive ||
                nature == MonsterNature.Rash;
        }
        public static bool LowersSpeed(MonsterNature nature)
        {
            return nature == MonsterNature.Brave ||
                nature == MonsterNature.Relaxed ||
                nature == MonsterNature.Quiet ||
                nature == MonsterNature.Sassy;
        }
    }
}
