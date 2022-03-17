using Entitas;
using UnityEngine;

public class AlignWithVelocitySystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _targetEntities;

    public AlignWithVelocitySystem(Contexts contexts)
    {
        _targetEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Velocity, GameMatcher.AlignToVelocity));
    }

    public void Execute()
    {
        foreach (var e in _targetEntities.GetEntities())
        {
            if (e.velocity.Magnitude < 0) continue;
            
            var velocity = e.velocity.Direction;
            var targetAngle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
            var angle = Mathf.LerpAngle(e.direction.Value, targetAngle, e.alignToVelocity.AlignSpeed * Time.deltaTime);
            e.ReplaceDirection(angle);
        }
    }
}