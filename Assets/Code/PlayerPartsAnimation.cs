using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerPartsAnimation : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private Transform hat;
    [SerializeField] private float ballSpinMultiply;
    [SerializeField] private float hatTiltMultiply;
    [SerializeField] private float hatTiltLimit;
    
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        var ballRotation = _playerMove.Speed * ballSpinMultiply;
        var position = ball.transform.position;
        ball.RotateAround(position, Vector3.right, ballRotation.z);
        ball.RotateAround(position, Vector3.up, ballRotation.x);

        var hatTilt = _playerMove.Speed * hatTiltMultiply;
        hat.eulerAngles = new Vector3(ClampHatTilt(-hatTilt.z), 0, ClampHatTilt(hatTilt.x));
    }

    private float ClampHatTilt(float value)
    {
        var tilt = (value / (_playerMove.MaxSpeed * hatTiltMultiply)) * hatTiltLimit;
        return tilt;
    }
}
