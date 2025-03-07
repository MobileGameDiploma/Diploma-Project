using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private FixedJoystick _joystick;
    private float _speed;

    private CinemachineVirtualCamera _cam;
    private float _minCameraAngle;
    private float _maxCameraAngle;
    private float _cameraMovementSpeed;
    private CinemachineTransposer _transposer;

    [Inject]
    private void Construct(PlayerConfig playerConfig, CameraConfig cameraConfig)
    {
        _rb = playerConfig.Rigidbody;
        _joystick = playerConfig.joystick;
        _speed = playerConfig.Speed;

        _cam = cameraConfig.VirtualCamera;
        _minCameraAngle = cameraConfig.MinCameraAngle;
        _maxCameraAngle = cameraConfig.MaxCameraAngle;
        _cameraMovementSpeed = cameraConfig.Speed;
        _transposer = _cam.GetCinemachineComponent<CinemachineTransposer>();
    }


    private void Update()
    {
        //_rb.velocity = new Vector3(_joystick.Horizontal * _speed, _rb.velocity.y, _joystick.Vertical * _speed);
        _rb.AddForce(new Vector3(_joystick.Horizontal * _speed, _rb.velocity.y, _joystick.Vertical * _speed) * Time.deltaTime, ForceMode.VelocityChange);

        float angleValue = GetMaxAxis();


        if (angleValue != 0 && _transposer.m_FollowOffset.y < _maxCameraAngle)
        {
            _transposer.m_FollowOffset.y += Math.Abs(angleValue) * _cameraMovementSpeed * Time.deltaTime;
        }
        if (_transposer.m_FollowOffset.y >= _minCameraAngle && angleValue == 0)
        {
            _transposer.m_FollowOffset.y -= _cameraMovementSpeed * Time.deltaTime;
        }
    }


    private float GetMaxAxis()
    {
        if(Math.Abs(_joystick.Horizontal) > Math.Abs(_joystick.Vertical))
            return _joystick.Horizontal;
        else
            return _joystick.Vertical;
    }
}
