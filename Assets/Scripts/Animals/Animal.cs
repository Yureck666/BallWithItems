using System.Collections;
using UnityEngine;

namespace BallGame.Animals
{
    public abstract class Animal: MonoBehaviour
    {
        [SerializeField] private WatchArea watchArea;
        [SerializeField] private float checkInterval;
        [SerializeField] private DetectionType detectionType;

        private Coroutine _checkCoroutine;
        private YieldInstruction _intervalInstruction;
        
        protected Component _target;

        private void Awake()
        {
            SubclassInit();
            _intervalInstruction = new WaitForSeconds(checkInterval);
            
            var type = TargetClassDetection.DetectionType[detectionType];
            
            watchArea.Init();
            watchArea.SetDetectionType(type);
            watchArea.TriggerEnterEvent.AddListener((arg) =>
            {
                _target = arg;
                _checkCoroutine = StartCoroutine(IntervalCheck());
            });
            watchArea.TriggerExitEvent.AddListener((arg) =>
            {
                if (_checkCoroutine != null)
                {
                    StopCoroutine(_checkCoroutine);
                    _checkCoroutine = null;
                    BreakCheck();
                }
            });
        }

        private IEnumerator IntervalCheck()
        {
            while (true)
            {
                Check();
                yield return _intervalInstruction;
            }
        }

        protected abstract void Check();
        protected abstract void BreakCheck();
        protected abstract void SubclassInit();
    }
}