using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NSingleton
{
    public class Singleton
        : MonoBehaviour
    {
        static Singleton _singleton = null;

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

