using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Type.Creature.Goblin;
using Creature;

namespace Factory.Creature.Goblin
{
    public class GoblinFactory
        : MonsterFactory
    {
        protected override Monster Create<T>(T type)
        {
            try
            {
                switch (Enum.Parse(typeof(EGoblinType), type.ToString()))
                {
                    case EGoblinType.Thief:
                        return new ThiefGoblin();
                }
            }
            catch
            {

            }


            return null;
        }
    }
}

