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
        : MonoBehaviour
        , PuzzleTouchManager.IObserver
    {
        PuzzleFactory _puzzleFactory;
        PuzzleFactory.IDataProvider _iPuzzleFactoryDataProvider;

        FloorManager.IDataProvider _iFloorDataProvider;

        List<Puzzle> _puzzleList;

        private void Awake()
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
                    if (random <= 50)
                    {
                        //    puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Currency, ECurrencyType.Gold);
                        puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Currency, ECurrencyType.Gold);
                    }
                    else 
                    {
                        puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Equipment, EEquipmentType.Sword);
                        puzzle = _iPuzzleFactoryDataProvider.CreateMonsterPuzzle(EDragonType.Ice, EDifficultyType.FinalBoss);
                        //Debug.Log("puzzle.Get<Monster>().MonsterInfo.MonsterType : " + puzzle.Get<Monster>().MonsterInfo.MonsterType);
                    }

                    //puzzle = _iPuzzleFactoryDataProvider.CreatePuzzle(EPuzzleType.Monster, EDragonType.Ice);

                    if (puzzle != null)
                    {
                        puzzle.Create(transform, puzzleIndex++);
          
                        puzzlePositionX = GetPuzzlePositionX(puzzle, column, puzzlePositionX);
                        puzzlePositionY = GetPuzzlePositionY(puzzle, row);

                        puzzle.SetPuzzlePosition(new Vector2Int(puzzlePositionX, puzzlePositionY));

                        _puzzleList.Add(puzzle);
                    }
                }
            }
        }

        private void TouchedPuzzle(List<int> touchPuzzleIndexList)
        {
            if(touchPuzzleIndexList.IsNullOrEmpty() == true)
            {
                return;
            }

            if(_puzzleList.IsNullOrEmpty() == true)
            {
                return;
            }

            Puzzle puzzle = null;

            foreach(int touchPuzzleIndex in touchPuzzleIndexList)
            {
                puzzle = _puzzleList.Find(e => e.PuzzleInfo.Index == touchPuzzleIndex);

                if(puzzle == null ||
                   puzzle.PuzzleInfo == null)
                {
                    continue;
                }

                Debug.Log("puzzle : " + puzzle.PuzzleInfo.Index + " / " + puzzle.PuzzleInfo.EPuzzleType);
            }
        }

        #region Get Puzzle Position 
        int GetPuzzlePositionX(Puzzle puzzle, int column, int puzzlePositionX)
        {
            if(puzzle == null ||
               puzzle.PuzzleBoxCollider == null)
            {
                return 0;
            }

            var width = puzzle.PuzzleBoxCollider.size.x;

            if (column == 0)
            {
                return (int)(width / 2) - (int)(width * NUtility.GameData.MaxPuzzleColumn) / 2;
            }

            return puzzlePositionX + (int)width;
        }

        int GetPuzzlePositionY(Puzzle puzzle, int row)
        {
            if (puzzle == null ||
                puzzle.PuzzleBoxCollider == null)
            {
                return 0;
            }

            var height = puzzle.PuzzleBoxCollider.size.y;

            var startPositionY = (int)(height * NUtility.GameData.MaxPuzzleRow) / 2 - (int)(height / 2);
            
            return (int)height * row - startPositionY;
        }
        #endregion

        void PuzzleTouchManager.IObserver.Change(List<int> touchedPuzzleIndexList)
        {
            TouchedPuzzle(touchedPuzzleIndexList);
        }
    }
}

