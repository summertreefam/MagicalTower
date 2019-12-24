using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NPuzzle;
using NGame.NPuzzle.NItem;
using NGame.NPuzzle.NMonster;
using NGame.NPuzzle.NFactory;
using NGame.NType;
using NGame.NType.NMonster;

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
            InitPuzzleFactory();
            InitPuzzleList();

            SetPuzzleList();
        }

        void InitPuzzleList()
        {
            _puzzleList = new List<Puzzle>();
            _puzzleList.Clear(); 
        }

        void InitPuzzleFactory()
        {
            _puzzleFactory = new PuzzleFactory();
            _iPuzzleFactoryDataProvider = _puzzleFactory as PuzzleFactory.IDataProvider;

            var puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Monster, EDragonType.Ice);
     
            Debug.Log("puzzle.Get<Monster>().MonsterInfo.MonsterType : " + puzzle.Get<Monster>().MonsterInfo.MonsterType);
            puzzle.Get<Monster>().Attack();
        }

        private void SetPuzzleList()
        {
            if(_iFloorDataProvider == null)
            {
                return;
            }

            if(_iPuzzleFactoryDataProvider == null)
            {
                return;
            }

            var currentFloorData = _iFloorDataProvider.GetCurrentFloorData();

            if (currentFloorData == null)
            {
                return;
            }

            Puzzle puzzle = null;

            int random = 0;

            for (int row = 0; row < NUtility.GameData.MaxPuzzleRow; ++row)
            {
                for(int column = 0; column < NUtility.GameData.MaxPuzzleColumn; ++column)
                {
                    random = UnityEngine.Random.Range(1, 100);
                    Debug.Log("random : " + random);
                    if(random <= 10) 
                    {
                        puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Currency, ECurrencyType.Gold);
                    }
                    else if(random <= 50)
                    {
                        puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Monster, EDragonType.Fire);
                    }
                    else
                    {
                        puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Monster, EDragonType.Ice);
                        Debug.Log("puzzle.Get<Monster>().MonsterInfo.MonsterType : " + puzzle.Get<Monster>().MonsterInfo.MonsterType);
                    }

                    if(puzzle != null)
                    {
                        //puzzle.Create()

                           
                    }
                }
            }
        }
    }
}

