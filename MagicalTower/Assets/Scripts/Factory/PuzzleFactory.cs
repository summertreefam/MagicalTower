using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType;

namespace NGame.NPuzzle.NFactory
{
    public class PuzzleFactory 
        : PuzzleFactory.IDataProvider
    {
        public interface IDataProvider
        {
            Puzzle CreatePuzzle<T>(EPuzzleType ePuzzleType, T tType) where T : Enum;
        }

        MonsterFactory _monsterFactory;
        ItemFactory _itemFactory;

        public PuzzleFactory()
        {
            InitFactory();
        }

        void InitFactory()
        {
            _monsterFactory = new MonsterFactory();
            _itemFactory = new ItemFactory();
        }

        #region Create Puzzle
        Puzzle CreateMonsterPuzzle<T>(T tType) where T : Enum
        {
            if(_monsterFactory == null)
            {
                return null;
            }

            return _monsterFactory.CreateMonster(tType);
        }

        Puzzle CreateItemPuzzle<T>(T tType) where T : Enum
        {
            if (_itemFactory == null)
            {
                return null;
            }

            return _itemFactory.Create(tType);
        }

        Puzzle IDataProvider.CreatePuzzle<T>(EPuzzleType ePuzzleType, T tType)
        {
            switch (ePuzzleType)
            {
                case EPuzzleType.Monster:
                    return CreateMonsterPuzzle(tType);

                case EPuzzleType.Item:
                    return CreateItemPuzzle(tType);

                default:
                    return null;
            }
        }
        #endregion
    }
}
