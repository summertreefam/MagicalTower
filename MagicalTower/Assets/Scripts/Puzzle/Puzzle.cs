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
        EPuzzleType GetEPuzzleType();
        string GetPuzzleImageName();
    }

    public class Puzzle
    {
        public PuzzleInfo PuzzleInfo { get; private set; }
        public BoxCollider2D PuzzleBoxCollider 
        { 
            get
            {
                if(_puzzlePref == null)
                {
                    return null;
                }

                return _puzzlePref.BoxCollider;
            }
        }

        IPuzzle _iPuzzle;
        PuzzlePref _puzzlePref;

        protected void Create(IPuzzle iPuzzle)
        {
            if (iPuzzle == null)
            {
                return;
            }

            _iPuzzle = iPuzzle;

            PuzzleInfo = PuzzleInfo.Create();
            PuzzleInfo.EPuzzleType = _iPuzzle.GetEPuzzleType();
        }

        public void Create(Transform parentTransform, int index)
        {
            _puzzlePref = PuzzlePref.Create(new PuzzlePref.PuzzlePrefInfo()
            {
                ParentTransform = parentTransform,
                PuzzleIndex = index,
            });

            SetPuzzleSprite();
        }

        public void SetPuzzlePosition(Vector2Int position)
        {
            if(PuzzleInfo != null)
            {
                PuzzleInfo.Position = position;
            }

            if(_puzzlePref != null)
            {
                _puzzlePref.SetPosition(position);
            }
        }

        private void SetPuzzleSprite()
        {
            if(_puzzlePref == null)
            {
                return;
            }

            if(_iPuzzle == null)
            {
                return;
            }

            _puzzlePref.SetSprite(_iPuzzle.GetPuzzleImageName());
        }

        public T Get<T>() where T : Puzzle
        {
            return _iPuzzle.Get<T>();
        }
    }
}

