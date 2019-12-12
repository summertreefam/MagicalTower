using System.Collections;
using System.Collections.Generic;
using NGame.NLayer;
using UnityEngine;

using NGame.NPuzzle;
using NGame.NPuzzle.NFactory;
using NGame.NData;

namespace NGame.NManager
{
    public class PuzzleManager
    {
        PuzzleFactory _puzzleFactory;
        PuzzleFactory.IDataProvider _iPuzzleFactoryDataProvider;

        FloorManager.IDataProvider _iFloorDataProvider;

        List<Puzzle> _puzzleList;

        public PuzzleManager(FloorManager.IDataProvider iFloorDataProvider)
        {
            _iFloorDataProvider = iFloorDataProvider;

            Init();
        }

        private void Init()
        {
            InitPuzzleInfoList();
            InitPuzzleFactory();
        }

        void InitPuzzleInfoList()
        {
            _puzzleList = new List<Puzzle>();
            _puzzleList.Clear();

            SetPuzzleInfoList();
        }

        void InitPuzzleFactory()
        {
            _puzzleFactory = new PuzzleFactory();
            _iPuzzleFactoryDataProvider = _puzzleFactory as PuzzleFactory.IDataProvider;

            var puzzle = _iPuzzleFactoryDataProvider.CreateMonsterPuzzle(NType.NMonster.NDragon.EDragonType.Fire);
        }

        private void SetPuzzleInfoList()
        {
            if(_iFloorDataProvider == null)
            {
                return;
            }

            var currentFloorData = _iFloorDataProvider.GetCurrentFloorData();

            if (currentFloorData == null)
            {
                return;
            }

            Puzzle puzzle = null;

            for(int row = 0; row < NUtility.GameData.MaxPuzzleRow; ++row)
            {
                for(int column = 0; column < NUtility.GameData.MaxPuzzleColumn; ++column)
                {

                }
            }
        }
    }
}

