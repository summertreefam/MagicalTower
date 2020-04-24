using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType;
using NGame.NType.NMonster;

namespace NGame.NInfo
{
    public class MonsterInfo 
    {
        public EMonsterType EMonsterType { get; set; }
        public string SubMonsterType { get; set; }
        public EDifficultyType EDifficultyType { get; set; }
    }
}
