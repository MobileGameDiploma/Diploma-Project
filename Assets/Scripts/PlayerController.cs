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
        AdjustCameraHeight();
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical) * _speed * Time.fixedDeltaTime;
        //_rb.MovePosition(transform.position + movement);
        transform.position += movement;
    }

    private void AdjustCameraHeight()
    {
        float angleValue = GetMaxAxis();

        if (angleValue != 0 && _transposer.m_FollowOffset.y < _maxCameraAngle)
        {
            _transposer.m_FollowOffset.y += Math.Abs(angleValue) * _cameraMovementSpeed * Time.deltaTime;
        }
        else if (_transposer.m_FollowOffset.y > _minCameraAngle && angleValue == 0)
        {
            _transposer.m_FollowOffset.y -= _cameraMovementSpeed * Time.deltaTime;
            // Smoothly return to min height
            _transposer.m_FollowOffset.y = Mathf.Max(_transposer.m_FollowOffset.y, _minCameraAngle);
        }
    }

    private float GetMaxAxis()
    {
        return Mathf.Max(Math.Abs(_joystick.Horizontal), Math.Abs(_joystick.Vertical));
    }
}

