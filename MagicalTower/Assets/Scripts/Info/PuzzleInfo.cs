using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NType;

namespace NGame.NInfo
{
    public class PuzzleInfo
    {
        public int Index { get; set; }
        public EPuzzleType EPuzzleType { get; set; } 
        public Vector2Int Position { get; set; }

        public static PuzzleInfo Create()
        {
            return new PuzzleInfo()
            {
                Index = 0,
                EPuzzleType = EPuzzleType.Disable,
                Position = Vector2Int.zero,
            };
        }
    }
}

