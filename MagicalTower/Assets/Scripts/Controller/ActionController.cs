using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NController.NAction
{
    public class ActionController 
        : MonoBehaviour
    {
        private void Start()
        {
            NFactory.MonsterFactory factory = new NFactory.NDragon.DragonFactory();
            factory.CreateMonster(NType.NDragon.EDragonType.Fire);

            factory = new NFactory.NGoblin.GoblinFactory();
            factory.CreateMonster(NType.NGoblin.EGoblinType.Thief);
        }
    }
}

