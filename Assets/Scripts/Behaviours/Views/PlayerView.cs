using Behaviours.ViewListeners;
using Configs;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[RequireComponent(typeof(PositionListener), 
                  typeof(DirectionListener), 
                  typeof(AnimatorVelocityListener))]
public class PlayerView : SelfInitializedView
{
    private PlayerConfig _playerConfig;

    [Inject]
    protected void Initialize(PlayerConfig playerConfig)
    {
        _playerConfig = playerConfig;
    }

    protected override void SetupEntityComponents()
    {
        base.SetupEntityComponents();
        Entity.isPlayer = true;
        Entity.AddMove(_playerConfig.speed, _playerConfig.acceleration);
        Entity.AddVelocity(Vector3.zero);
        Entity.AddStoppingDistance(_playerConfig.stoppingDistance);
        Entity.isMoveCommandListener = true;
        Entity.AddAlignToVelocity(_playerConfig.alignToVelocitySpeed);
    }
}