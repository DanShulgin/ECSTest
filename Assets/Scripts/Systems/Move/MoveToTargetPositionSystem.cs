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
        foreach (var e in _movesToTargetPosition.GetEntities())
        {
            var dir = e.moveTargetPosition.Value - e.position.Value;
            e.ReplaceTargetVelocity(dir.normalized, e.move.Speed);

            var dist = dir.magnitude;
            var stoppingDistance = e.hasStoppingDistance ? e.stoppingDistance.Value : 0.1f;
            
            if (dist <= stoppingDistance)
            {
                e.RemoveMoveTargetPosition();
                e.isMoveComplete = true;
                e.ReplaceTargetVelocity(e.targetVelocity.Direction,0f);
            }
        }
    }

    public void Cleanup()
    {
        foreach (var e in _moveCompletes.GetEntities())
        {
            e.isMoveComplete = false;
        }
    }
}