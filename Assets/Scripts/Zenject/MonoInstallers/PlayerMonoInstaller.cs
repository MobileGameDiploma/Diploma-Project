using Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerMonoInstaller : MonoInstaller
{
    [Header("Technical parts")]
    public Rigidbody Rigidbody;
    public FixedJoystick PlayerJoyStick;
    public CinemachineVirtualCamera VirtualCamera;
    public CharacterController CharacterController;

    [Header("Technical Parameters")]
    [Range(12, 20)]
    public float MaxCameraAngle = 16;
    public float MinCameraAngle = 11;

    [Header("Player Parameters")]
    public float Speed;
    [Range(1, 10)]public float CameraMoveSpeed;
    public PlayerStats PlayerStats;
    
    [Header("Player Object")]
    public GameObject PlayerObject;
    
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
        _playerConfig = new PlayerConfig(Rigidbody, PlayerJoyStick);
        _cameraConfig = new CameraConfig(VirtualCamera, MaxCameraAngle, MinCameraAngle, CameraMoveSpeed);
    }

    private void SetBindings()
    {
        Container.Bind<PlayerStats>().FromInstance(PlayerStats);
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
        Container.Bind<CameraConfig>().FromInstance(_cameraConfig).AsSingle();
        Container.Bind<CharacterController>().FromInstance(CharacterController).AsSingle();
        Container.Bind<GameObject>().WithId("Player").FromInstance(PlayerObject).AsSingle();
    }
}
