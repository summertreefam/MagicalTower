using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NCamera
{
    public class GameCamera 
        : MonoBehaviour
    {
        void Awake()
        {
            //Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}

