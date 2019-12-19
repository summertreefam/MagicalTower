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
        #endregion

        public static int MaxPuzzleRow = 6;
        public static int MaxPuzzleColumn = 7;
    }
}

