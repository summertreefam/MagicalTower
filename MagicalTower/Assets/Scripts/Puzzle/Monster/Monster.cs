using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NInfo;
using NGame.NType;

namespace NGame.NPuzzle.NMonster
{
    public interface IAction
    {
        void Attack();
        void Move();
    }
    
    public class Monster 
        : Puzzle
        , IPuzzle
    {
        public MonsterInfo MonsterInfo { get; private set; }

        protected IAction _iAction;

        public void Create(ETribeType eTribeType)
        {
            base.Create(this);

            MonsterInfo = new MonsterInfo()
            {
                ETribeType = eTribeType,
            };
        }

        Monster IPuzzle.Get<Monster>()
        {
            return this as Monster;
        }

        public void Attack()
        {
            Debug.Log("Monster Attack");

            if(_iAction != null)
            {
                _iAction.Attack();
            }
        }

        public void Move()
        {

        }

    }
}

