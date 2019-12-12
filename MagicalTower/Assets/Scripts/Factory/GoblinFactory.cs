using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType.NMonster.NGoblin;
using NGame.NPuzzle.NMonster.NGoblin;
using NGame.NPuzzle.NMonster;
using NGame.NType;

namespace NGame.NPuzzle.NFactory
{
    public class GoblinFactory
        : BaseMonsterFactory
    {
        public override ETribeType ETribeType
        {
            get
            {
                return ETribeType.MGoblin;
            }
        }

        protected override Monster Create<T>(T type)
        {
            try
            {
                switch (Enum.Parse(typeof(T), Enum.GetName(typeof(T), type)))
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

