using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType.NMonster.NDragon;
using NGame.NPuzzle.NMonster;
using NGame.NPuzzle.NMonster.NDragon;
 
namespace NGame.NPuzzle.NFactory
{
    public class DragonFactory
        : BaseMonsterFactory
    {
        protected override Monster Create<T>(T type)
        {
            try
            {
                switch (Enum.Parse(typeof(T), Enum.GetName(typeof(T), type)))
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


