using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NInfo;
using NGame.NType;

namespace NGame.NPuzzle.NMonster
{
    public class Monster 
        : Puzzle
    {
        MonsterInfo _monsterInfo;

        public void Create(ETribeType eTribeType)
        {
            _monsterInfo = new MonsterInfo()
            {
                ETribeType = eTribeType,
            };
        }
    }
}

