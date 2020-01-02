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

            var puzzleGameObj = Instantiate(Resources.Load(puzzlePrefabPath)) as GameObject;

            if(puzzleGameObj == null)
            {
                return null;
            } 

            puzzleGameObj.transform.parent = parentTranform;
            puzzleGameObj.transform.localScale = Vector3.one;
            puzzleGameObj.transform.localPosition = Vector3.zero;

            return puzzleGameObj;
        }
    }
}

