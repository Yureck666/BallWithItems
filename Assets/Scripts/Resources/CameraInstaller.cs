using UnityEngine;
using Zenject;

namespace BallGame.Resources
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraMove cameraMove;
        public override void InstallBindings()
        {
            Container.Bind<CameraMove>().FromInstance(cameraMove).AsSingle().NonLazy();
        }
    }
}