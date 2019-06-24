using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller.Action
{
    public class ActionController 
        : MonoBehaviour
    {
        private void Start()
        {
            Factory.Creature.MonsterFactory factory = new Factory.Creature.Dragon.DragonFactory();

            factory.CreateMonster(Type.Creature.Dragon.EDragonType.Ice.ToString());

            factory = new Factory.Creature.Goblin.GoblinFactory();

            factory.CreateMonster(Type.Creature.Goblin.EGoblinType.Thief.ToString());
        }


    }
}

