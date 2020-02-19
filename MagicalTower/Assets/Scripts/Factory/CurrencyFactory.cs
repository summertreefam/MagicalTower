using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType;

namespace NGame.NPuzzle.NFactory
{
    public class CurrencyFactory
    {
        public Currency Create<T>(T tType)
        {
            Currency currency = new Currency();

            try
            {
                ECurrencyType type = (ECurrencyType)Enum.Parse(typeof(T), Enum.GetName(typeof(T), tType));

                if (currency != null)
                {
                    Debug.Log("Currency type : " + type);
                    currency.Create(type);
                }
            }
            catch
            {

            }

            return currency;
        }
    }
}

