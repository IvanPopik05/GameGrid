using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GenerateElements _generateElements;
        private void Start()
        {
            GameFactory gameFactory = new GameFactory();
            _generateElements.Initialize(gameFactory);
        }
    }
}