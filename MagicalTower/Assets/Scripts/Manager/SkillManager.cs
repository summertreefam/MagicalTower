using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NManager.NSkill
{
    public class SkillManager 
        : NSingleton.LazySingleton<SkillManager>
    {
        public void Test()
        {

            Debug.Log("Test");
        }
    }
}

