using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NAction;

namespace NMonster.NDragon
{
    public abstract class Dragon
        : Monster
        , IAction
    {
        public abstract void Attack();
        public abstract void Move();
    }
}

 