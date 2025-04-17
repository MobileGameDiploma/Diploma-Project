using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig
{
    public Rigidbody Rigidbody;
    public FixedJoystick joystick;
    public LayerMask UIActivationLayer;

    public PlayerConfig(Rigidbody rigidbody, FixedJoystick joystick, LayerMask activationLayer)
    {
        Rigidbody = rigidbody;
        this.joystick = joystick;
    }
}
