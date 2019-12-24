using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType;

namespace NGame.NData
{
    [Serializable]
    public class FloorData 
    {
        public int Floor { get; set; }
        public int[] DisablePuzzles { get; set; }
        public int LimitTurn { get; set; }
        public int TotalMonsterCount { get; set; }
        public EMonsterType[] EMonsterTypes { get; set; }
        public bool IsMidBoss { get; set; }
        public string LastBoss { get; set; }

        public static FloorData Create()
        {
            return new FloorData
            {
                Floor = 1,
                DisablePuzzles = null,
                TotalMonsterCount = 1,
                EMonsterTypes = null,
            };
        }
    }
}

