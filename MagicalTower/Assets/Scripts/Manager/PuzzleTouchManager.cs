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
            if(Input.GetMouseButtonDown(0) == true)
            {
                MouseClick();

                return;
            }

            if(Input.touchCount > 0)
            {
                Touch();

                return;
            }
        }

        void MouseClick()
        {
            Debug.Log("GetMouseButtonDown");

            //Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            //Vector2 touchPos = new Vector2(wp.x, wp.y);
            //foreach()

            //if (collider2D == Physics2D.OverlapPoint(touchPos))
            //{

            //}
            
            return;
        }

        void Touch()
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("PuzzleTouchManager Began Touch");
                    break;
            }
        }
    }
}

