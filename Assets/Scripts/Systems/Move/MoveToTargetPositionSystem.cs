using Entitas;
using UnityEngine;

public class MoveToTargetPositionSystem : IExecuteSystem, ICleanupSystem
{
    readonly IGroup<GameEntity> _movesToTargetPosition;
    readonly IGroup<GameEntity> _moveCompletes;

    public MoveToTargetPositionSystem(Contexts contexts)
    {
        _movesToTargetPosition = contexts.game.GetGroup(GameMatcher.MoveTargetPosition);
        _moveCompletes = contexts.game.GetGroup(GameMatcher.MoveComplete);
    }

    public void Execute()
    {
        foreach (GameEntity e in _movesToTargetPosition.GetEntities())
        {
            Vector3 dir = e.moveTargetPosition.Value - e.position.Value;
            Vector3 velocity = dir.normalized * e.move.Speed;
            e.ReplaceTargetVelocity(velocity);

            float dist = dir.magnitude;
            var stoppingDistance = e.hasStoppingDistance ? e.stoppingDistance.Value : 0.1f;
            
            if (dist <= stoppingDistance)
            {
                e.RemoveMoveTargetPosition();
                e.isMoveComplete = true;
            }
        }
    }

    public void Cleanup()
    {
        foreach (var e in _moveCompletes.GetEntities())
        {
            e.isMoveComplete = false;
            e.RemoveTargetVelocity();
            e.ReplaceVelocity(Vector3.zero);
        }
    }
}