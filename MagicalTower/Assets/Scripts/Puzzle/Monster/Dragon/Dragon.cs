using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NPuzzle.NMonster;
using System;

namespace NGame.NPuzzle.NMonster.NDragon
{
    public abstract class Dragon
        : Monster
        , IAction
    {
        protected Dragon()
        {
            _iAction = this;
        }

        protected abstract new void Attack();

        protected abstract new void Move();
    }
}

 