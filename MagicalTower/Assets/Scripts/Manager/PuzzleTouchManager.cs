using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using NGame.NPuzzle;

namespace NGame.NManager
{
    public class PuzzleTouchManager
        : MonoBehaviour
    {
        public interface IObserver
        {
            void Change(List<int> touchedPuzzleIndexList);
        }

        int[] Ranges = new int[] { 1, 5, 6, 7, };

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

            if (Input.GetMouseButtonUp(0) == true)
            {
                _touchPuzzleIndexList.Clear();

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

                case TouchPhase.Ended:
                    _touchPuzzleIndexList.Clear();
                    break;

                case TouchPhase.Canceled:
                    _touchPuzzleIndexList.Clear();
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
            int puzzleIndex = 0;

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

            puzzleIndex = puzzlePrefab.PuzzleIndex;

            if (_touchPuzzleIndexList.Contains(puzzleIndex) == true)
            {
                return;
            }

            if(CheckPossibleRange(puzzleIndex) == false)
            {
                return;
            }

            _touchPuzzleIndexList.Add(puzzleIndex);


            foreach(int index in _touchPuzzleIndexList)
            {
                Debug.Log("index : " + index);
            }
            if(_iObserverList != null)
            {
                _iObserverList.ForEach(e => e.Change(_touchPuzzleIndexList));
            }
        }

        bool CheckPossibleRange(int puzzleIndex)
        {
            if (_touchPuzzleIndexList == null)
            {
                return false;
            }

            if (_touchPuzzleIndexList.Count <= 0)
            {
                return true;
            }

            int lastPuzzleIndex = _touchPuzzleIndexList[_touchPuzzleIndexList.Count - 1];
            int result = Mathf.Abs(lastPuzzleIndex - puzzleIndex);

            if(Ranges.ToList().Contains(result) == false)
            {
                return false;
            }

            return true;
        }
    }
}

