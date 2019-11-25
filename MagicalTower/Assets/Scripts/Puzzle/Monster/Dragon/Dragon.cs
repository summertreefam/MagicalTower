using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NAction;
using NGame.NPuzzle.NMonster;

namespace NGame.NPuzzle.NMonster.NDragon
{
    public abstract class Dragon
        : Monster
        , IAction
    {
        public abstract void Attack();
        public abstract void Move();
    }
}

 