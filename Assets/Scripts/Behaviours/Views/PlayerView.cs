using Behaviours.ViewListeners;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PositionListener), 
                  typeof(DirectionListener), 
                  typeof(AnimatorVelocityListener))]
public class PlayerView : SelfInitializedView
{
    protected override void Initialize()
    {
        base.Initialize();
        Entity.isPlayer = true;
        Entity.AddMove(5f, 10f);
        Entity.AddVelocity(Vector3.zero);
        Entity.AddStoppingDistance(0.05f);
        Entity.isMoveCommandListener = true;
        Entity.AddAlignToVelocity(10f);
    }
}