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
        GameObject _puzzlePrefGameObj;

        protected void Create(IPuzzle iPuzzle)
        {
            _iPuzzle = iPuzzle;

            PuzzleInfo = PuzzleInfo.Create();
        }

        public void Create(Transform parentTransform)
        {
            if(PuzzleInfo == null)
            {
                return;
            }

            _puzzlePrefGameObj = PuzzlePref.Create(parentTransform);
        }

        public T Get<T>() where T : Puzzle
        {
            return _iPuzzle.Get<T>();
        }
    }
}

