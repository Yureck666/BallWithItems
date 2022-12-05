using System;
using UnityEngine;
using UnityEngine.Events;

namespace BallGame.Animals
{
    [RequireComponent(typeof(Collider))]
    public class WatchArea: MonoBehaviour
    {
        private Collider _collider;
        private Type _detectionType;
        
        public UnityEvent<Component> TriggerEnterEvent { get; private set; }
        public UnityEvent<Component> TriggerExitEvent { get; private set; }

        public void Init()
        {
            _collider = GetComponent<Collider>();
            TriggerEnterEvent = new UnityEvent<Component>();
            TriggerExitEvent = new UnityEvent<Component>();
        }

        public void SetDetectionType(Type t)
        {
            if (!t.IsSubclassOf(typeof(MonoBehaviour)))
            {
                Debug.Log($"Wrong class type {t.Name}");
                return;
            }
            _detectionType = t;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(_detectionType, out var target))
            {
                TriggerEnterEvent.Invoke(target);
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(_detectionType, out var target))
            {
                TriggerExitEvent.Invoke(target);
            }
        }
    }
}