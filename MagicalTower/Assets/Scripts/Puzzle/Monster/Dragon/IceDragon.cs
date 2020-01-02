using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NPuzzle.NMonster.NDragon
{
    public class IceDragon
        : Dragon
    {
        public IceDragon()
        {
            //Debug.Log("Ice Dragon");
        }

        protected override void Attack()
        {
            Debug.Log("Ice Dragon Attack()");
        }

        protected override void Move()
        {

        }
    }
}
