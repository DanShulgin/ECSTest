using Entitas;
using UnityEngine;

public class VelocitySystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _moves;

    public VelocitySystem(Contexts contexts)
    {
        _moves = contexts.game.GetGroup(GameMatcher.TargetVelocity);
    }

    public void Execute()
    {
        foreach (GameEntity e in _moves.GetEntities())
        {
            float targetSpeed = e.targetVelocity.Value.magnitude;
            float currentSpeed = e.velocity.Value.magnitude + e.move.Acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, targetSpeed);
            e.ReplaceVelocity(currentSpeed * e.targetVelocity.Value.normalized);
            
            Vector3 newPosition = e.position.Value + e.velocity.Value * Time.deltaTime;
            e.ReplacePosition(newPosition);
        }
    }
}