using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NPuzzle
{
    public class PuzzlePref
        : MonoBehaviour
    {
        public class PuzzlePrefInfo
        {
            public Transform ParentTransform;
            public int PuzzleIndex;
        }

        public int PuzzleIndex { get { return _puzzleIndex; } }

        int _puzzleIndex;

        public static PuzzlePref Create(PuzzlePrefInfo info)
        {
            if(info == null ||
               info.ParentTransform == null)
            {
                return null;
            }

            var puzzlePrefabPath = NUtility.GameData.PrefabPath + "/Puzzle";
            var puzzleGameObj = Instantiate(Resources.Load(puzzlePrefabPath)) as GameObject;

            if(puzzleGameObj == null)
            {
                return null;
            }

            var puzzlePref = puzzleGameObj.GetComponent<PuzzlePref>();

            if(puzzlePref == null)
            {
                return null;
            }

            puzzlePref.Init(info.PuzzleIndex);

            puzzleGameObj.transform.parent = info.ParentTransform;
            puzzleGameObj.transform.localScale = Vector3.one;
            puzzleGameObj.transform.localPosition = Vector3.zero;

            return puzzlePref;
        }

        private void Init(int puzzleIndex)
        {
            _puzzleIndex = puzzleIndex;
        }

        public void SetPosition(Vector2Int positon)
        {
            if(transform == null)
            {
                return;
            }

            transform.localPosition = new Vector3(positon.x, positon.y, transform.localPosition.z);
        }

        public void SetSprite(string imgPath)
        {
            var spriteRendrer = GetComponent<SpriteRenderer>();

            if (spriteRendrer == null)
            {
                return;
            }

            var sprite = Resources.Load<Sprite>("Images/" + imgPath);

            if (sprite == null)
            {
                return;
            }

            spriteRendrer.sprite = sprite;
        }

        public BoxCollider2D BoxCollider
        {
            get
            {
                return GetComponent<BoxCollider2D>();
            }
        }
    }
}

