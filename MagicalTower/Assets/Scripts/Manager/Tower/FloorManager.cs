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
        FloorData _floorData;

        public List<FloorData> FloorDataList { get { return _floorDataList; } set { _floorDataList = value; } }

        public FloorManager()
        {
            LoadJson();
        }

        public void CreateFloor(int floor)
        {
            
        }

        public FloorData GetFloorData()
        {
            return _floorData;
        }

        void LoadJson()
        {
            _floorDataList.Clear();

            if (File.Exists(NUtility.GameData.FloorDataFilePath) == true)
            {
                var jsonString = File.ReadAllText(NUtility.GameData.FloorDataFilePath);
                var jsonDatas = JsonHelper.FromJson(jsonString);

                var floorData = new FloorData();

                List<int> disablePuzzleList = new List<int>();

                foreach (LitJson.JsonData jsonData in jsonDatas)
                {
                    floorData = new FloorData();

                    floorData.Floor = int.Parse(jsonData["Floor"].ToString());

                    //if(jsonData["DisablePuzzles"].IsArray == true)
                    {
                        disablePuzzleList.Clear();

                        foreach (string disablePuzzle in jsonData["DisablePuzzles"])
                        {
                            disablePuzzleList.Add(int.Parse(disablePuzzle));
                        }

                        floorData.DiablePuzzles = disablePuzzleList.ToArray();
                    }
                    
                    floorData.TotalMonsterCount = int.Parse(jsonData["TotalMonsterCount"].ToString());
                    floorData.LimitTurn = int.Parse(jsonData["LimitTurn"].ToString());

                    _floorDataList.Add(floorData);
                }
            }
        }
    }
}

