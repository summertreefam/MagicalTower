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

            _puzzleTouchManager = gameObject.AddComponent<PuzzleTouchManager>();
        }
    }
}

