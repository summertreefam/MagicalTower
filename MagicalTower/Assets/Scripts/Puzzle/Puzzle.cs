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
        public BoxCollider PuzzleBoxCollider 
        { 
            get
            {
                if(_puzzlePrefGameObj == null)
                {
                    return null;
                }

                return _puzzlePrefGameObj.GetComponent<BoxCollider>();
            }
        }

        IPuzzle _iPuzzle;
        GameObject _puzzlePrefGameObj;

        protected void Create(IPuzzle iPuzzle)
        {
            _iPuzzle = iPuzzle;

            PuzzleInfo = PuzzleInfo.Create();
        }

        public void Create(Transform parentTransform, int index)
        {
            _puzzlePrefGameObj = PuzzlePref.Create(parentTransform);

            SetPuzzleIndex(index);
        }

        void SetPuzzleIndex(int index)
        {
            if (PuzzleInfo != null)
            {
                PuzzleInfo.Index = index;
            }

            if (_puzzlePrefGameObj == null)
            {
                return;
            }

            var puzzlePrefab = _puzzlePrefGameObj.GetComponent<PuzzlePref>();

            if(puzzlePrefab == null)
            {
                return;
            }

            puzzlePrefab.PuzzleIndex = index;
        }

        public void SetPuzzlePosition(Vector2Int position)
        {
            if(PuzzleInfo != null)
            {
                PuzzleInfo.Position = position;
            }

            if(_puzzlePrefGameObj != null)
            {
                _puzzlePrefGameObj.transform.localPosition = new Vector3(position.x, position.y, _puzzlePrefGameObj.transform.localPosition.z);
            }
        }

        public T Get<T>() where T : Puzzle
        {
            return _iPuzzle.Get<T>();
        }
    }
}

