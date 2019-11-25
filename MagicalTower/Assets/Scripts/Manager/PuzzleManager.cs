using System.Collections;
using System.Collections.Generic;
using NGame.NLayer;
using UnityEngine;

using NGame.NFactory;

namespace NGame.NManager
{
    public class PuzzleManager
        : MonoBehaviour
        , GameLayer.IPuzzleDataListener
    {
        PuzzleFactory _puzzleFactory = new PuzzleFactory();

        public PuzzleManager()
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        int GameLayer.IPuzzleDataListener.GetIndex()
        {
            return 1;
        }

    }
}

