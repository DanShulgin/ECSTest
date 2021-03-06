using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<NavMeshService>().AsSingle();
        }
    }
}