using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

using NGame.NData;
using NUtility.NHelper;

namespace NGame.NManager
{
    public class FloorManager 
        : MonoBehaviour
        , FloorManager.IDataProvider
    {
        public interface IDataProvider
        {
            FloorData GetCurrentFloorData();
        }

        List<FloorData> _floorDataList = new List<FloorData>();
        FloorData _currentFloorData;

        public FloorManager()
        {
            Init();
        }

        void Init()
        {
            if (JsonHelper.LoadJsonFloorDataList(out _floorDataList) == true)
            {
                _currentFloorData = GetCurrentFloorData(1);
            }
        }

        FloorData GetCurrentFloorData(int floor)
        {
            return _floorDataList.Find(floorData => floorData.Floor == floor);
        }

        FloorData IDataProvider.GetCurrentFloorData()
        {
            return _currentFloorData;
        }
    }
}

