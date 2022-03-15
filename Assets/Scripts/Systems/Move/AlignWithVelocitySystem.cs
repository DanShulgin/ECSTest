using Entitas;
using UnityEngine;

public class AlignWithVelocitySystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _targetEntities;

    public AlignWithVelocitySystem(Contexts contexts)
    {
        _targetEntities = contexts.game.GetGroup(GameMatcher.Velocity);
    }

    public void Execute()
    {
        foreach (GameEntity e in _targetEntities.GetEntities())
        {
            if(!e.hasAlignToVelocity) continue;
            
            var velocity = e.velocity.Value;
            var targetAngle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
            var angle = Mathf.Lerp(e.direction.value, targetAngle, e.alignToVelocity.AlignSpeed * Time.deltaTime);
            e.ReplaceDirection(angle);
        }
    }
}