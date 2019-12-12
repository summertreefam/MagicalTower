using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NInfo
{
    public enum EPuzzleType
    {
        Disable,

        Monster,

        Gold,
    }

    public class PuzzleInfo
    {
        public int Index { get; set; }
        public EPuzzleType EPuzzleType { get; set; } 
        public int Row { get; set; }
        public int Column { get; set; }
    }
}

