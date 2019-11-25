using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NAction;

namespace NGame.NPuzzle.NMonster.NGoblin
{
    public abstract class Goblin
        : Monster
        , IAction
    {
        public abstract void Attack();
        public abstract void Move();
    }
}

