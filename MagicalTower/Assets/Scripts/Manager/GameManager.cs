using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NManager
{
    public class GameManager 
        : MonoBehaviour
    {
        public PuzzleManager PuzzleManager;

        FloorManager _floorManager;
        PuzzleTouchManager _puzzleTouchManager;

        private void Start()
        {
            Init();
        }

        #region Init
        private void Init()
        {
            InitManager();
        }

        void InitManager()
        {
            _floorManager = new FloorManager();

            if(PuzzleManager != null)
            {
                PuzzleManager.Init(_floorManager);
            }

            InitPuzzleTouchManager();
        }

        private void InitPuzzleTouchManager()
        {
            _puzzleTouchManager = gameObject.AddComponent<PuzzleTouchManager>();

            AddObserverByPuzzleTouchManager();
        }

        private void AddObserverByPuzzleTouchManager()
        {
            if(_puzzleTouchManager != null)
            {
                _puzzleTouchManager.AddObserver(PuzzleManager);
            }
        }
        #endregion
    }
}

