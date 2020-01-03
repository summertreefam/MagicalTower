using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NPuzzle;

namespace NGame.NManager
{
    public class PuzzleTouchManager
        : MonoBehaviour
    {
        public interface IObserver
        {
            void Change(List<int> touchPuzzleIndexList);
        }

        List<IObserver> _iObserverList;

        List<int> _touchPuzzleIndexList;

        void Start()
        {
            _touchPuzzleIndexList = new List<int>();
            _touchPuzzleIndexList.Clear();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) == true ||
                Input.GetMouseButton(0) == true)
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

        private void InitObserverList()
        {
            _iObserverList = new List<IObserver>();
            _iObserverList.Clear();
        }

        public void AddObserver(IObserver iObserver)
        {
            if(_iObserverList == null)
            {
                InitObserverList();
            }

            _iObserverList.Add(iObserver);
        }

        void MouseClick()
        {
            TouchPuzzle(Input.mousePosition);
        }

        void Touch()
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                case TouchPhase.Moved:
                    Debug.Log("PuzzleTouchManager Began Touch");
                    TouchPuzzle(touch.position);
                    break;

                case TouchPhase.Canceled:
                    break;
            }
        }

        void TouchPuzzle(Vector3 position)
        {
            if(_touchPuzzleIndexList == null)
            {
                return;
            }

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

            if(_touchPuzzleIndexList.Contains(puzzlePrefab.PuzzleIndex) == true)
            {
                return;
            }

            _touchPuzzleIndexList.Add(puzzlePrefab.PuzzleIndex);

            if(_iObserverList != null)
            {
                _iObserverList.ForEach(e => e.Change(_touchPuzzleIndexList));
            }
        }
    }
}

