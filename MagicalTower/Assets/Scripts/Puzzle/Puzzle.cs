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
                if(_puzzlePrefGameObj == null)
                {
                    return null;
                }

                return _puzzlePrefGameObj.GetComponent<BoxCollider2D>();
            }
        }

        IPuzzle _iPuzzle;
        GameObject _puzzlePrefGameObj;

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
            _puzzlePrefGameObj = PuzzlePref.Create(parentTransform);

            SetPuzzleIndex(index);
            SetPuzzleSprite();
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

        private void SetPuzzleSprite()
        {
            if(_puzzlePrefGameObj == null)
            {
                return;
            }

            if(_iPuzzle == null)
            {
                return;
            }

            var spriteRendrer = _puzzlePrefGameObj.GetComponent<SpriteRenderer>();

            if (spriteRendrer == null)
            {
                return;
            }

            var imgPath = "Images/" + _iPuzzle.GetPuzzleImageName();
            var sprite = Resources.Load<Sprite>(imgPath);

            if(sprite == null)
            { 
                return;
            }

            spriteRendrer.sprite = sprite;
        }

        public T Get<T>() where T : Puzzle
        {
            return _iPuzzle.Get<T>();
        }
    }
}

