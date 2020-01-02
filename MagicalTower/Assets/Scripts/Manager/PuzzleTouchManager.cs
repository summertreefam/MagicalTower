using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NPuzzle;

namespace NGame.NManager
{
    public class PuzzleTouchManager
        : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("PuzzleTouchManager Start");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                MouseClick();

                return;
            }

            if (Input.touchCount > 0)
            {
                Touch();

                return;
            }
        }

        void MouseClick()
        {
            TouchPuzzle(Input.mousePosition);

            return;
        }

        void Touch()
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("PuzzleTouchManager Began Touch");
                    TouchPuzzle(touch.position);
                    break;

                case TouchPhase.Moved:
                    break;
            }
        }

        void TouchPuzzle(Vector3 position)
        {
            var touchPosition = Camera.main.ScreenToWorldPoint(position);

            var hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit == false)
            {
                return;   
            }

            var transform = hit.transform;

            if (transform == null ||
                transform.gameObject == null)
            {
                return;
            }

            var puzzlePrefab = transform.gameObject.GetComponent<PuzzlePref>();

            if (puzzlePrefab == null)
            {
                return;
            }

            Debug.Log("puzzlePrefab.PuzzleIndex : " + puzzlePrefab.PuzzleIndex);
        }
    }
}

