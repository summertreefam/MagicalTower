using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NInfo;
using NGame.NType;

namespace NGame.NPuzzle
{
    public interface IPuzzle
    {
        T Get<T>() where T : Puzzle;
    }

    public class Puzzle
    {
        public PuzzleInfo PuzzleInfo { get; private set; }

        IPuzzle _iPuzzle;

        protected void Create(IPuzzle iPuzzle)
        {
            _iPuzzle = iPuzzle;
        }

        public void Create(int index, EPuzzleType ePuzzleType, Vector2Int position)
        {
            PuzzleInfo = new PuzzleInfo()
            {
                Index = index,
                EPuzzleType = ePuzzleType,
                Position = position,
            };
        }

        public T Get<T>() where T : Puzzle
        {
            return _iPuzzle.Get<T>();
        }
    }
}

