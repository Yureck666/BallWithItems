using System;
using UnityEngine;
using Zenject;

namespace BallGame
{
    public class DistributorSpawner : MonoBehaviour
    {
        [SerializeField] private DistributorPosition[] distributors;
    
        [Inject] private DiContainer _container;

        [Serializable]
        private class DistributorPosition
        {
            [SerializeField] private Transform position;
            [SerializeField] private ItemsDistributor distributor;

            public Transform Position => position;
            public ItemsDistributor Distributor => distributor;
        }
        private void Awake()
        {
            foreach (var distributor in distributors)
            {
                var dist = _container.InstantiatePrefab(distributor.Distributor);
                dist.transform.position = distributor.Position.position;
                dist.transform.rotation = distributor.Position.rotation;
            }
        }
    }
}
