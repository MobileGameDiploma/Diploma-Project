using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMonoInstaller : MonoInstaller
{
    [Header("Technical parts")]
    public Rigidbody Rigidbody;
    public FixedJoystick PlayerJoyStick;

    [Header("Player Parameters")]
    public float Speed;

    public override void InstallBindings()
    {
        PlayerConfig playerConfig = new PlayerConfig(Rigidbody, PlayerJoyStick, Speed);

        Container.Bind<PlayerConfig>().FromInstance(playerConfig).AsSingle();
    }
}
