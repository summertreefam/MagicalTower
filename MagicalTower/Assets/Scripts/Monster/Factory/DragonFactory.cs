using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NType.NDragon;
using NMonster;
using NMonster.NDragon;

namespace NFactory.NDragon
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


