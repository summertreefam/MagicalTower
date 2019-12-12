using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NGame.NManager;

namespace NGame.NLayer
{
    public class GameLayer 
        : MonoBehaviour
    {
        GameManager _gameManager;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        void InitGameManager()
        {
            _gameManager = new GameManager();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

