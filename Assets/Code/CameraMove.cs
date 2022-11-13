using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float distanceMultiplyBySpeed;
    
    [Inject] private PlayerMove _player;

    private Vector3 _delta;

    private void Awake()
    {
        _delta = transform.position - _player.transform.position;
    }

    private void Update()
    {
        transform.position = _player.transform.position + _delta + (_delta * _player.FloatSpeed * distanceMultiplyBySpeed);
    }
}
