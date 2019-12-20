using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NType;
using NGame.NInfo;

namespace NGame.NPuzzle
{
    public class Currency
        : Puzzle
    {
        public CurrencyInfo CurrencyInfo { get; private set; }

        public void Create(ECurrencyType eCurrencyType)
        {
            CurrencyInfo = new CurrencyInfo()
            {
                ECurrencyType = eCurrencyType,
            };
        }
    }
}

