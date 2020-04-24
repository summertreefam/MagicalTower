using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

using NGame.NInfo;
using NGame.NType;
using NGame.NType.NMonster;

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

        public void Create<T>(Type type, T subType, EDifficultyType eDifficultyType)
        {
            base.Create(this);

            MonsterInfo = new MonsterInfo()
            {
                EMonsterType = GetEMonsterType(type),
                SubMonsterType = Enum.Parse(typeof(T), Enum.GetName(typeof(T), subType)).ToString(),
                EDifficultyType = eDifficultyType,
            };
        }

        EMonsterType GetEMonsterType(Type type)
        {
            foreach (EMonsterType monsterType in Enum.GetValues(typeof(EMonsterType)))
            {
                if (type.ToString().Contains(monsterType.ToString()) == true)
                {
                    return monsterType;
                }
            }

            return EMonsterType.Basic;
        }

        #region IPuzzle
        Monster IPuzzle.Get<Monster>()
        {
            return this as Monster;
        }

        EPuzzleType IPuzzle.GetEPuzzleType()
        {
            return EPuzzleType.Monster;
        }

        string IPuzzle.GetPuzzleImageName()
        {
            if (MonsterInfo == null)
            {
                return string.Empty;
            }

            return "Monster/" + MonsterInfo.EMonsterType.ToString() + "/" + MonsterInfo.SubMonsterType + "_" + MonsterInfo.EDifficultyType;
        }
        #endregion

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

