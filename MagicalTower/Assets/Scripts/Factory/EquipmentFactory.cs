using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType;

namespace NGame.NPuzzle.NFactory
{
    public class EquipmentFactory
    {
        public Equipment Create<T>(T tType)
        {
            Equipment equipment = new Equipment();

            try
            {
                EEquipmentType type = (EEquipmentType)Enum.Parse(typeof(T), Enum.GetName(typeof(T), tType));

                switch (type)
                {
                    case EEquipmentType.Sword:
       

                        break;

                    case EEquipmentType.Bow:
                        break;
                }

                if (equipment != null)
                {
                    equipment.Create(type);
                }
            }
            catch
            {

            }

            return equipment;
        }
    }
}

