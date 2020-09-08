using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NInfo;
using NGame.NType;

namespace NGame.NPuzzle.NItem
{
    public interface IAction
    {
        void Use();
    }

    public class Item 
        : Puzzle
        , IPuzzle
    {
        public ItemInfo ItemInfo { get; private set; }

        protected IAction _iAction;

        public void Create(EItemType eItemType)
        {
            base.Create(this);

            ItemInfo = new ItemInfo()
            {
                EItemType = eItemType,
            };
        }

        #region IPuzzle
        Item IPuzzle.Get<Item>()
        {
            return this as Item;
        }

        EPuzzleType IPuzzle.GetEPuzzleType()
        {
            return EPuzzleType.Item;
        }

        string IPuzzle.PuzzleImageName
        {
            get
            {
                if (ItemInfo == null)
                {
                    return string.Empty;
                }

                switch (ItemInfo.EItemType)
                {
                    case EItemType.HpPotion:
                        return "";

                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        public void Use()
        {
            if(_iAction != null)
            {
                _iAction.Use();
            }
        }
    }
}

