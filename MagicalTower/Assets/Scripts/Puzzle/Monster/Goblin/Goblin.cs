using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NPuzzle.NMonster.NGoblin
{
    public abstract class Goblin
        : Monster
        , IAction
    {
        protected Goblin()
        {
            _iAction = this;
        }
        public abstract new void Attack();
        public abstract new void Move();
    }
}

