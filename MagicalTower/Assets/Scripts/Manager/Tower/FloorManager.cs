using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

using NGame.NData;
using NUtility.NHelper;

namespace NGame.NManager.NTower
{
    public class FloorManager 
        : MonoBehaviour
    {
        List<FloorData> _floorDataList = new List<FloorData>();

        public FloorManager()
        {
            Init();
        }

        void Init()
        {
            if (JsonHelper.LoadJsonFloorDataList(out _floorDataList) == true)
            {

            }
        }

        public void CreateFloor(int floor)
        {
            
        }
    }
}

