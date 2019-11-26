using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NManager.NTower;

namespace NGame.NManager
{
    public class GameManager 
        : MonoBehaviour
    {
        PuzzleManager _puzzleManager;
        TowerManager _towerManager;

        void Start()
        {
            InitPuzzleManager();
            InitTowerManager();
        }

        void InitPuzzleManager()
        {
            _puzzleManager = new PuzzleManager();
        }

        void InitTowerManager()
        {
            _towerManager = new TowerManager();
        }
    }
}

