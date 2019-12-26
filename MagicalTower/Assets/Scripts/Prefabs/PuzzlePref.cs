using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NPuzzle
{
    public class PuzzlePref
        : MonoBehaviour
    {
        public static GameObject Create(Transform parentTranform)
        {
            var puzzlePrefabPath = NUtility.GameData.PrefabPath + "/Puzzle";

            var puzzleGameObject = Instantiate(Resources.Load(puzzlePrefabPath)) as GameObject;
            puzzleGameObject.transform.parent = parentTranform;
            puzzleGameObject.transform.localScale = Vector3.one;
            puzzleGameObject.transform.localPosition = Vector3.zero;

            return puzzleGameObject;
        }
    }
}

