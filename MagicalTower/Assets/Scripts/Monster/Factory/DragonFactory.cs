using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Creature;
using Type.Creature.Dragon;

namespace Factory.Creature.Dragon
{
    public class DragonFactory
        : MonsterFactory
    {
        protected override Monster Create<T>(T type)
        {
            try
            {
                switch (Enum.Parse(typeof(EDragonType), type.ToString()))
                {
                    case EDragonType.Fire:
                        return new FireDragon();
                }
            }
            catch
            {

            }

            return null;
        }
    }
}


