using Configs;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "ScriptableObject/ConfigInstaller", order = 0)]
    public class ConfigInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private DoorConfig doorConfig;
        [SerializeField] private PlayerConfig playerConfig;

        public override void InstallBindings()
        {
            Container.Bind<DoorConfig>().FromInstance(doorConfig);
            Container.Bind<PlayerConfig>().FromInstance(playerConfig);
        }
    }
}