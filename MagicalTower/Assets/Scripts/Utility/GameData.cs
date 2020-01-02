using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NUtility
{
    public class GameData
    {
        #region Path
        public static string DataPath = Application.dataPath + "/Resources";
        public static string FloorDataFilePath = DataPath + "/GameData/FloorData.json";

        public static string PrefabPath = "Prefabs";
        #endregion

        public static int MaxPuzzleRow = 7;
        public static int MaxPuzzleColumn = 6;
    }
}

