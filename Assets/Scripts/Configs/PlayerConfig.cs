using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig
{
    public Rigidbody Rigidbody;
    public FixedJoystick joystick;
    public float Speed;

    public PlayerConfig(Rigidbody rigidbody, FixedJoystick joystick, float speed)
    {
        Rigidbody = rigidbody;
        this.joystick = joystick;
        Speed = speed;
    }
}
