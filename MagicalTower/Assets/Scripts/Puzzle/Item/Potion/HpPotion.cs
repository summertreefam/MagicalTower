using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NPuzzle.NItem
{
    public class HpPotion
        : Item
        , IAction
    {
        public HpPotion()
        {
            _iAction = this;
        }

        void IAction.Use()
        {

        }
    }
}

