using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NType.NMonster.NDragon;
using NGame.NType.NMonster.NGoblin;

namespace NGame.NPuzzle.NFactory
{
    public class PuzzleFactory 
        : MonoBehaviour
    {
        MonsterFactory _monsterFactory;

        public PuzzleFactory()
        {
            InitMonsterFactory();
        }

        void InitMonsterFactory()
        {
            _monsterFactory = new MonsterFactory();
        }

        void CreatePuzzle()
        {
        }
    }
}
