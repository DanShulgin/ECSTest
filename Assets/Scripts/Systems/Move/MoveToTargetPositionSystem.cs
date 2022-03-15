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
            Vector3 newPosition = e.position.Value + dir.normalized * e.move.Speed * Time.deltaTime;
            e.ReplacePosition(newPosition);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            e.ReplaceDirection(angle);

            float dist = dir.magnitude;
            var stoppingDistance = e.hasStoppingDistance ? e.stoppingDistance.Value : 0.5f;
            
            if (dist <= stoppingDistance)
            {
                e.RemoveMoveTargetPosition();
                e.isMoveComplete = true;
            }
        }
    }

    public void Cleanup()
    {
        foreach (GameEntity e in _moveCompletes.GetEntities())
        {
            e.isMoveComplete = false;
        }
    }
}