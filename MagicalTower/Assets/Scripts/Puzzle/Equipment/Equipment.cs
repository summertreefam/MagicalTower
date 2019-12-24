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
    }
}

