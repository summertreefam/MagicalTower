using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NPuzzle.NMonster;
using NGame.NType.NMonster.NDragon;

namespace NGame.NPuzzle.NFactory
{
    public abstract class BaseMonsterFactory
    {
        public Monster CreateMonster<T>(T type) where T : Enum
        {
            return Create(type);
        }

        abstract protected Monster Create<T>(T type) where T : Enum;
    }

    public class MonsterFactory
    {
        List<BaseMonsterFactory> _monsterFactoryList;

        public MonsterFactory()
        {
            _monsterFactoryList = new List<BaseMonsterFactory>();
            _monsterFactoryList.Clear();

            _monsterFactoryList.Add(new DragonFactory());
            _monsterFactoryList.Add(new GoblinFactory());
        }

        public Monster CreateMonster<T>(T type) where T : Enum
        {
            Monster monster = null;

            foreach(var monsterFactory in _monsterFactoryList)
            {
                if(monsterFactory == null)
                {
                    continue;
                }

                monster = monsterFactory.CreateMonster(type);

                if (monster != null)
                {
                    break;
                }
            }

            return monster;
        }
    }
}

