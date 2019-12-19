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

        Item IPuzzle.Get<Item>()
        {
            return this as Item;
        }

        public void Use()
        {
            if(_iAction != null)
            {
                _iAction.Use();
            }
        }
    }
}

