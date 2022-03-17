using Systems.DoorMechanic;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ECSInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var contexts = Contexts.sharedInstance;

            Container.BindInstance(contexts);

            foreach (var context in contexts.allContexts)
            {
                Container.Bind(context.GetType()).FromInstance(context).AsSingle();
            }
            
            BindSystems();
            
            Container.BindInterfacesTo<MainBootstrap>().AsSingle().NonLazy();
        }
        
        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<EmitInputSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GroundButtonPressSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<MoveCommandSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveToTargetPositionSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TargetVelocitySystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<VelocitySystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<AlignWithVelocitySystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveAlongPathSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameEventSystems>().AsSingle();
        }
    }
}