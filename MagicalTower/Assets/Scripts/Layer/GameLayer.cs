using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NManager;

namespace NGame.NLayer
{
    public class GameLayer 
        : MonoBehaviour
    {
        public interface IPuzzleDataListener
        {
            int GetIndex();
        }

        PuzzleManager _puzzleManager = new PuzzleManager();
        IPuzzleDataListener _iPuzzleDataLister;

        // Start is called before the first frame update
        void Start()
        {
            _iPuzzleDataLister = _puzzleManager as IPuzzleDataListener;
        }

        // Update is called once per frame
        void Update()
        {

        }

        int GetIndex
        {
            get
            {
                if(_iPuzzleDataLister == null)
                {
                    return 0;
                }

                return _iPuzzleDataLister.GetIndex();
            }
        }
    }
}

