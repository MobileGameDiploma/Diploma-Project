using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig
{
    public Rigidbody Rigidbody;
    public FixedJoystick joystick;

    public PlayerConfig(Rigidbody rigidbody, FixedJoystick joystick)
    {
        Rigidbody = rigidbody;
        this.joystick = joystick;
    }
}
