using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType;
using NGame.NPuzzle.NItem;

namespace NGame.NPuzzle.NFactory
{
    public class ItemFactory 
    {
        public Item Create<T>(T tType)
        {
            Item item = null;

            try
            {
                EItemType type = (EItemType)Enum.Parse(typeof(T), Enum.GetName(typeof(T), tType));

                switch (type)
                {
                    case EItemType.HpPotion:
                        item = new HpPotion();
                        break;

                }

                if(item != null)
                {
                    item.Create(type);
                }
            }
            catch
            {

            }

            return item;
        }
    }
}


