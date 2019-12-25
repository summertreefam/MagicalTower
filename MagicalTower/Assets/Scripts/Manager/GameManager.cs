using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NManager
{
    public class GameManager 
        : MonoBehaviour
    {
        PuzzleManager _puzzleManager;
        FloorManager _floorManager;
        PuzzleTouchManager _puzzleTouchManager;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            InitManager();
        }

        void InitManager()
        {
            _floorManager = new FloorManager();
            _puzzleManager = new PuzzleManager(_floorManager);

            _puzzleTouchManager = gameObject.AddComponent<PuzzleTouchManager>();
        }
    }
}

