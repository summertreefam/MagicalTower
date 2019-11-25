using System.Collections;
using System.Collections.Generic;
using NGame.NLayer;
using UnityEngine;

using NGame.NPuzzle;
using NGame.NPuzzle.NFactory;

namespace NGame.NManager
{
    public class PuzzleManager
        : MonoBehaviour
    {
        List<Puzzle> _puzzleList;

        PuzzleFactory _puzzleFactory;

        public PuzzleManager()
        {
            InitPuzzleInfoList();
            InitPuzzleFactory();
        }

        void InitPuzzleInfoList()
        {
            _puzzleList = new List<Puzzle>();
            _puzzleList.Clear();
        }

        void InitPuzzleFactory()
        {
            _puzzleFactory = new PuzzleFactory();
        }
    }
}

