using System;
using UnityEngine;
using Zenject;

namespace BallGame
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float speedChangeValue;
        [SerializeField] private float stopChangeSpeed;
        [SerializeField] private float maxSpeed;

        [Inject] private DynamicJoystick _dynamicJoystick;

        private Vector3 _speed;
        private Vector2 _pointerDownPosition;
        private CharacterController _characterController;

        public Vector3 Speed => _speed;
        public float FloatSpeed => Vector3.Distance(_speed, Vector3.zero);
        public float MaxSpeed => maxSpeed;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var targetSpeed = GetSpeed(_dynamicJoystick.Direction);
            var distance = Vector3.Distance(_speed, targetSpeed);
            var delta = Math.Clamp((distance > maxSpeed ? stopChangeSpeed : speedChangeValue) / distance, 0, 1);
            _speed = Vector3.Lerp(_speed, targetSpeed, delta);

            _characterController.Move((_speed + Physics.gravity) * Time.deltaTime);
        }

        private Vector3 GetSpeed(Vector2 direction)
        {
            var speed = new Vector3(direction.x, 0, direction.y);
            speed *= maxSpeed;
            return speed;
        }
    }
}