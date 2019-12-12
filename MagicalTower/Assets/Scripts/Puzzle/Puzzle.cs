using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NInfo;
using NGame.NPuzzle.NMonster;

namespace NGame.NPuzzle
{
    public class Puzzle 
    {
        public PuzzleInfo PuzzleInfo { get; private set; }

        public void Create(int index, EPuzzleType ePuzzleType, int row, int column)
        {
            PuzzleInfo = new PuzzleInfo()
            {
                Index = index,
                EPuzzleType = ePuzzleType,
                Row = row,
                Column = column,
            };
        }
    }
}

