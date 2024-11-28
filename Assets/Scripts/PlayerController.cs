using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private FixedJoystick _joystick;

    private float _speed;

    [Inject]
    private void Construct(PlayerConfig playerConfig)
    {
        _rb = playerConfig.Rigidbody;
        _joystick = playerConfig.joystick;
        _speed = playerConfig.Speed;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal * _speed, _rb.velocity.y, _joystick.Vertical * _speed);
    }
}
