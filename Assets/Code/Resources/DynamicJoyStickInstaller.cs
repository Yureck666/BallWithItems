using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DynamicJoyStickInstaller : MonoInstaller
{
    [SerializeField] private DynamicJoystick inputCatcher;
    public override void InstallBindings()
    {
        Container.Bind<DynamicJoystick>().FromInstance(inputCatcher).AsSingle().NonLazy();
    }
}
