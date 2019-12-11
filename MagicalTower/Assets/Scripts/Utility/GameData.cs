using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NUtility
{
    public class GameData
    {
        #region Path
        public static string FloorDataFilePath = Application.dataPath + "/Resources/GameData/FloorData.json";
        #endregion

        public static int MaxPuzzleRow = 6;
        public static int MaxPuzzleColumn = 7;
    }
}

