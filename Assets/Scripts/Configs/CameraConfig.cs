using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfig : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public float MaxCameraAngle;
    public float Speed;
    public float MinCameraAngle;

    public CameraConfig(CinemachineVirtualCamera camera, float maxCameraAngle, float minCameraAngle, float speed)
    {
        VirtualCamera = camera;
        MaxCameraAngle = maxCameraAngle;
        MinCameraAngle = minCameraAngle;
        Speed = speed;
    }
}
