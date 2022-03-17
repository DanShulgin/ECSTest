using System;
using Entitas;
using UnityEngine;

public class TargetVelocitySystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _moves;

    public TargetVelocitySystem(Contexts contexts)
    {
        _moves = contexts.game.GetGroup(GameMatcher.TargetVelocity);
    }

    public void Execute()
    {
        foreach (var e in _moves.GetEntities())
        {
            var targetSpeed = e.targetVelocity.Magnitude;
            var prevSpeed = e.velocity.Magnitude;
            float currentSpeed;
            if (targetSpeed > prevSpeed)
            {
                currentSpeed = prevSpeed + e.move.Acceleration * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, targetSpeed);
            }
            else
            {
                currentSpeed = prevSpeed - e.move.Deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0f);
            }
            
            e.ReplaceVelocity(e.targetVelocity.Direction, currentSpeed);
        }
    }
}