using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGame.NManager
{
    public class PuzzleTouchManager
        : MonoBehaviour
    {
        BoxCollider _boxCollider;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("PuzzleTouchManager Start");
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                switch(touch.phase)
                {
                    case TouchPhase.Began:
                        Debug.Log("PuzzleTouchManager Began Touch");
                        break;
                }
            }
        }
    }
}

