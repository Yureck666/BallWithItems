using System;
using UnityEngine;
using Zenject;

namespace BallGame
{
    public class TakerSpawner: MonoBehaviour
    {
        [SerializeField] private TakerPosition[] takers;
    
        [Inject] private DiContainer _container;

        [Serializable]
        private class TakerPosition
        {
            [SerializeField] private Transform position;
            [SerializeField] private ItemsTaker taker;

            public Transform Position => position;
            public ItemsTaker Taker => taker;
        }
        private void Awake()
        {
            foreach (var taker in takers)
            {
                var taker1 = _container.InstantiatePrefab(taker.Taker);
                taker1.transform.position = taker.Position.position;
                taker1.transform.rotation = taker.Position.rotation;
            }
        }
    }
}