﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Action;

namespace Creature
{
    public abstract class Dragon
        : Monster
        , IAction
    {
        public abstract void Attack();
        public abstract void Move();
    }
}

 