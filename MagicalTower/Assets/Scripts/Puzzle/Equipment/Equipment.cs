using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NInfo;
using NGame.NType;

namespace NGame.NPuzzle
{
    public class Equipment
        : Puzzle
        , IPuzzle
    {
        public EquipmentInfo EquipmentInfo { get; private set; }

        public void Create(EEquipmentType eEquipmentType)
        {
            base.Create(this);

            EquipmentInfo = new EquipmentInfo()
            {
                EEquipmentType = eEquipmentType,
            };
        }

        #region IPuzzle
        Equipment IPuzzle.Get<Equipment>()
        {
            return this as Equipment;
        }

        EPuzzleType IPuzzle.GetEPuzzleType()
        {
            return EPuzzleType.Equipment;
        }

        string IPuzzle.GetPuzzleImageName()
        {
            if(EquipmentInfo == null)
            {
                return string.Empty;
            }

            const string imgPath = "Equipment/";

            switch(EquipmentInfo.EEquipmentType)
            {
                case EEquipmentType.Sword:
                    return imgPath + "s_weapon100-hd";

                case EEquipmentType.Shield:
                    return imgPath + "assistance400-hd";

                default:
                    return string.Empty;
            }
        }
        #endregion

    }
}

