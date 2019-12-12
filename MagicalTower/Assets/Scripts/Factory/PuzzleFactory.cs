using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NGame.NType.NMonster.NDragon;
using NGame.NType.NMonster.NGoblin;

namespace NGame.NPuzzle.NFactory
{
    public class PuzzleFactory 
        : MonoBehaviour
        , PuzzleFactory.IDataProvider
    {
        public interface IDataProvider
        {
            Puzzle CreateMonsterPuzzle<T>(T type) where T : Enum;
        }

        MonsterFactory _monsterFactory;

        public PuzzleFactory()
        {
            InitMonsterFactory();
        }

        void InitMonsterFactory()
        {
            _monsterFactory = new MonsterFactory();
        }

        Puzzle IDataProvider.CreateMonsterPuzzle<T>(T type)
        {
            return _monsterFactory.CreateMonster(type);
        }
    }
}
