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

        public GameManager()
        {
            Init();
        }

        private void Init()
        {
            InitFloorManager();
            InitPuzzleManager();
        }

        void InitFloorManager()
        {
            _floorManager = new FloorManager();
        }

        void InitPuzzleManager()
        {
            if(_floorManager == null)
            {
                return;
            }

            _puzzleManager = new PuzzleManager(_floorManager);
        }
    }
}

