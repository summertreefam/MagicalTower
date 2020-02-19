using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NType;
using NGame.NInfo;

namespace NGame.NPuzzle
{
    public class Currency
        : Puzzle
        , IPuzzle
    {
        public CurrencyInfo CurrencyInfo { get; private set; }

        public void Create(ECurrencyType eCurrencyType)
        {
            base.Create(this);

            CurrencyInfo = new CurrencyInfo()
            {
                ECurrencyType = eCurrencyType,
            };
        }

        #region IPuzzle
        Currency IPuzzle.Get<Currency>()
        {
            return this as Currency;
        }

        EPuzzleType IPuzzle.GetEPuzzleType()
        {
            return EPuzzleType.Currency;
        }

        string IPuzzle.GetPuzzleImageName()
        {
            if(CurrencyInfo == null)
            {
                return string.Empty;
            }

            const string imgPath = "Currency/"; 

            switch(CurrencyInfo.ECurrencyType)
            {
                case ECurrencyType.Gold:
                    return imgPath + "gold-hd";

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}

