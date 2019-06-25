using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NMonster;

namespace NFactory
{
    public abstract class MonsterFactory
    {
        public Monster CreateMonster<T>(T type) where T : class
        {
            return Create(type);
        }

        abstract protected Monster Create<T>(T type) where T : class;
    }
}

