using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NPuzzle.NMonster;

namespace NGame.NPuzzle.NFactory
{
    public abstract class MonsterFactory
    {
        public Monster CreateMonster<T>(T type) where T : Enum
        {
            return Create(type);
        }

        abstract protected Monster Create<T>(T type) where T : Enum;
    }
}

