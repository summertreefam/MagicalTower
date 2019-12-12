using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using System.IO;

using NGame.NData;

namespace NUtility.NHelper
{
    public static class JsonHelper
    {
        public static JsonData FromJson(string json)
        {
            return JsonMapper.ToObject(json);
        }

        public static string ToJson<T>(T[] array)
        {
            return JsonMapper.ToJson(array);
        }

        #region Load Json
        public static bool LoadJsonFloorDataList(out List<FloorData> floorDataList)
        {
            List<FloorData> list = new List<FloorData>();
            list.Clear();

            floorDataList = list;

            if (File.Exists(GameData.FloorDataFilePath) == false)
            {
                return false;
            }

            var jsonString = File.ReadAllText(GameData.FloorDataFilePath);
            var jsonDatas = FromJson(jsonString);

            FloorData floorData = null;
            List<int> disablePuzzleList = new List<int>();

            foreach (JsonData jsonData in jsonDatas)
            {
                floorData = new FloorData();

                floorData.Floor = GetParseJsonData<int>(jsonData["Floor"]);
                floorData.DisablePuzzles = GetListParseJsonData<int>(jsonData["DisablePuzzles"]).ToArray();
                floorData.TotalMonsterCount = GetParseJsonData<int>(jsonData["TotalMonsterCount"]);
                floorData.LimitTurn = GetParseJsonData<int>(jsonData["LimitTurn"]);

                floorDataList.Add(floorData);
            }

            return true;
        }
        #endregion

        #region Parse Json Data
        private static T GetParseJsonData<T>(JsonData jsonData) 
        {
            if(jsonData == null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(jsonData.ToString(), typeof(T));
        }

        private static List<T> GetListParseJsonData<T>(JsonData jsonData) 
        {
            List<T> list = new List<T>();
            list.Clear();

            if (jsonData == null)
            {
                return list;
            }

            if (jsonData.IsArray == false)
            {
                return list;
            }

            foreach (var data in jsonData)
            {
                if(data == null)
                {
                    continue;
                }

                list.Add((T)Convert.ChangeType(data.ToString(), typeof(T)));
            }

            return list;
        }
        #endregion
    }
}

