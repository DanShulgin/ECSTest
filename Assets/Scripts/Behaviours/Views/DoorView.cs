using UnityEngine;

[RequireComponent(typeof(PositionListener))]
public class DoorView : SelfInitializedView
{
    protected override void Initialize()
    {
        base.Initialize();
        Entity.AddMove(2.5f, 20f);
        Entity.AddVelocity(Vector3.zero);
        Entity.AddStoppingDistance(0.01f);
        Entity.isDoor = true;
    }
}