using UnityEngine;
using System;

namespace NSingleton
{ 
    public class LazySingleton<T>
        where T : class, new()
    {
        static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}

