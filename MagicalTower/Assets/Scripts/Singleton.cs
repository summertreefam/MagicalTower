using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NSingleton
{
    public class Singleton
        : MonoBehaviour
    {
        static Singleton _singleton;

        public static Singleton Instance
        {
            get
            {
                if(_singleton == null)
                {
                    _singleton = new Singleton();
                }

                return _singleton;
            }
        }
    }
}

