using System.Collections;
using System.Collections.Generic;
using NGame.NData;
using UnityEngine;

namespace NGame.NManager.NTower
{
    public class TowerManager
        : MonoBehaviour
    {
        FloorManager _floorManager;

        public TowerManager()
        {
            InitFloorManager();
        }

        void InitFloorManager()
        {
            _floorManager = new FloorManager();
        }
    }
}

