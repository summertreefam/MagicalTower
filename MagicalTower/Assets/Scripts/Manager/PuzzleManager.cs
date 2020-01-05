﻿using System.Collections;
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
        : MonoBehaviour
        , PuzzleTouchManager.IObserver
    {
        PuzzleFactory _puzzleFactory;
        PuzzleFactory.IDataProvider _iPuzzleFactoryDataProvider;

        FloorManager.IDataProvider _iFloorDataProvider;

        List<Puzzle> _puzzleList;

        private void Start()
        {
            InitPuzzleFactory();
            InitPuzzleList();
        }

        public void Init(FloorManager.IDataProvider iFloorDataProvider)
        {
            if (iFloorDataProvider == null)
            {
                Debug.LogError("FloorManager.IDataProvider is null.");
                return;
            }

            _iFloorDataProvider = iFloorDataProvider;

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
     
            Debug.Log("puzzle.Get<Monster>().MonsterInfo.MonsterType : " + puzzle.Get<Monster>().MonsterInfo);
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

            int puzzlePositionX = 0;
            int puzzlePositionY = 0;
            int puzzleIndex = 0;

            int random = 0;

            for (int row = 0; row < NUtility.GameData.MaxPuzzleRow; ++row)
            {
                for(int column = 0; column < NUtility.GameData.MaxPuzzleColumn; ++column)
                {
                    random = UnityEngine.Random.Range(1, 100);
                    //Debug.Log("random : " + random);
                    //if(random <= 10) 
                    //{
                    //    puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Currency, ECurrencyType.Gold);
                    //}
                    //else if(random <= 50)
                    //{
                    //    puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Monster, EDragonType.Fire);
                    //}
                    //else
                    {
                        puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Monster, EDragonType.Ice);
                        //Debug.Log("puzzle.Get<Monster>().MonsterInfo.MonsterType : " + puzzle.Get<Monster>().MonsterInfo.MonsterType);
                    }

                    if(puzzle != null)
                    {
                        puzzle.Create(transform, puzzleIndex++);
          
                        puzzlePositionX = GetPuzzlePositionX(puzzle, column, puzzlePositionX);
                        puzzlePositionY = GetPuzzlePositionY(puzzle, row);

                        puzzle.SetPuzzlePosition(new Vector2Int(puzzlePositionX, puzzlePositionY));
                    }
                }
            }
        }

        int GetPuzzlePositionX(Puzzle puzzle, int column, int puzzlePositionX)
        {
            if(puzzle == null)
            {
                return 0;
            }

            if (column == 0)
            {
                return (int)(puzzle.PuzzleRect.width / 2) - (int)(puzzle.PuzzleRect.width * NUtility.GameData.MaxPuzzleColumn) / 2;
            }

            return puzzlePositionX + (int)puzzle.PuzzleRect.width;
        }

        int GetPuzzlePositionY(Puzzle puzzle, int row)
        {
            if (puzzle == null)
            {
                return 0;
            }

            var startPositionY = (int)(puzzle.PuzzleRect.height * NUtility.GameData.MaxPuzzleRow) / 2 - (int)(puzzle.PuzzleRect.height / 2);
            
            return (int)puzzle.PuzzleRect.height * row - startPositionY;
        }

        void PuzzleTouchManager.IObserver.Change(List<int> touchPuzzleIndexList)
        {
            Debug.Log("touchPuzzleIndexList : " + touchPuzzleIndexList.Count);
        }
    }
}

