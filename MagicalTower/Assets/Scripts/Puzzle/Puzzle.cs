using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NInfo;
using NGame.NPuzzle.NMonster;

namespace NGame.NPuzzle
{
    public class Puzzle 
    {
        protected PuzzleInfo _puzzleInfo;

        public Puzzle()
        {
            
        }

        public Puzzle(int index, EPuzzleType ePuzzleType, int row, int column)
        {
            _puzzleInfo = new PuzzleInfo()
            {
                Index = index,
                EPuzzleType = ePuzzleType,
                Row = row,
                Column = column,
            };
        }
    }
}

