using UnityEngine;
using Zenject;

namespace BallGame.Resources
{
    public class DynamicJoyStickInstaller : MonoInstaller
    {
        [SerializeField] private DynamicJoystick inputCatcher;
        public override void InstallBindings()
        {
            Container.Bind<DynamicJoystick>().FromInstance(inputCatcher).AsSingle().NonLazy();
        }
    }
}
