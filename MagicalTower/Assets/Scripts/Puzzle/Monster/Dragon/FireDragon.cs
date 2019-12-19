﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NGame.NPuzzle.NMonster.NDragon
{
    public class FireDragon 
        : Dragon
    {
        public FireDragon()
        {
            Debug.Log("FireDragon");
        }

        protected override void Attack()
        {
            Debug.Log("FireDragon Attack()");
        }

        protected override void Move()
        {
            
        }
    }
}

