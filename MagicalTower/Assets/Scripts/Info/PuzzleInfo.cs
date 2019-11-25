using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NInfo
{
    public enum EPuzzleType
    {
        Monster,

        Gold,

    }

    public class PuzzleInfo
    {
        public int Index { get; set; }
        public EPuzzleType EPuzzleType { get; set; } 


    }
}

