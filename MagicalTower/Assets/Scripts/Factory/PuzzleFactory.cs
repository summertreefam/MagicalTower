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
        CurrencyFactory _currencyFactory;
        EquipmentFactory _equipmentFactory;

        public PuzzleFactory()
        {
            InitFactory();
        }

        void InitFactory()
        {
            _monsterFactory = new MonsterFactory();
            _itemFactory = new ItemFactory();
            _currencyFactory = new CurrencyFactory();
            _equipmentFactory = new EquipmentFactory();
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

        Puzzle CreateCurrencyPuzzle<T>(T tType) where T : Enum
        {
            if (_currencyFactory == null)
            {
                return null;
            }

            return _currencyFactory.Create(tType);
        }

        Puzzle CreateEquipmentPuzzle<T>(T tType) where T : Enum
        {
            if(_equipmentFactory == null)
            {
                return null;
            }

            return _equipmentFactory.Create(tType);
        }

        Puzzle IDataProvider.CreatePuzzle<T>(EPuzzleType ePuzzleType, T tType)
        {
            Puzzle puzzle = null;

            switch (ePuzzleType)
            {
                case EPuzzleType.Monster:
                    puzzle = CreateMonsterPuzzle(tType);
                    break;

                case EPuzzleType.Item:
                    puzzle = CreateItemPuzzle(tType);
                    break;

                case EPuzzleType.Currency:
                    puzzle = CreateCurrencyPuzzle(tType);
                    break;

                case EPuzzleType.Equipment:
                    puzzle = CreateEquipmentPuzzle(tType);
                    break;
            }

            return puzzle;
        }
        #endregion
    }
}
