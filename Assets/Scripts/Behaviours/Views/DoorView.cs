using Configs;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PositionListener))]
public class DoorView : SelfInitializedView
{
    private DoorConfig _doorConfig;

    [Inject]
    protected void Initialize(DoorConfig doorConfig)
    {
        _doorConfig = doorConfig;
    }

    protected override void SetupEntityComponents()
    {
        base.SetupEntityComponents();
        Entity.AddMove(_doorConfig.speed, _doorConfig.acceleration, _doorConfig.deceleration);
        Entity.AddVelocity(Vector3.zero, 0f);
        Entity.AddStoppingDistance(_doorConfig.stoppingDistance);
        Entity.isDoor = true;
    }
}