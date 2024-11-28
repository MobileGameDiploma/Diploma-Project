using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using Zenject;

public class PlayerMonoInstaller : MonoInstaller
{
    [Header("Technical parts")]
    public Rigidbody Rigidbody;
    public FixedJoystick PlayerJoyStick;
    public CinemachineVirtualCamera VirtualCamera;

    [Header("Technical Parameters")]
    [Range(12, 20)]
    public float MaxCameraAngle = 16;
    public float MinCameraAngle = 11;

    [Header("Player Parameters")]
    public float Speed;
    [Range(1, 10)]public float CameraMoveSpeed;

    #region ObjectContainers
    private PlayerConfig _playerConfig;
    private CameraConfig _cameraConfig;
    #endregion

    public override void InstallBindings()
    {
        BuildObjects();
        SetBindings();
    }

    private void BuildObjects()
    {
        _playerConfig = new PlayerConfig(Rigidbody, PlayerJoyStick, Speed);
        _cameraConfig = new CameraConfig(VirtualCamera, MaxCameraAngle, MinCameraAngle, CameraMoveSpeed);
    }

    private void SetBindings()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
        Container.Bind<CameraConfig>().FromInstance(_cameraConfig).AsSingle();
    }
}
