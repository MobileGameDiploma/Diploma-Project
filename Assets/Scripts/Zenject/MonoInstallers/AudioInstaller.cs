using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [Header("Audio_Example")]
    public AudioSource AudioSource;

    public override void InstallBindings()
    {
        Container.Bind<AudioSource>().WithId("AudioSourceExample").FromInstance(AudioSource).AsSingle();
    }
}
