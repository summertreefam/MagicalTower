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
            _puzzleManager = new PuzzleManager();
            _towerManager = new TowerManager();
        }
    }
}

