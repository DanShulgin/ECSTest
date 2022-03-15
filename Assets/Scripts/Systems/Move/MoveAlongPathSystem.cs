using Entitas;
using UnityEngine;

public class MoveAlongPathSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _moveAlongPath;

    public MoveAlongPathSystem(Contexts contexts)
    {
        _moveAlongPath = contexts.game.GetGroup(GameMatcher.MoveAlongPath);
    }

    public void Execute()
    {
        foreach (GameEntity e in _moveAlongPath.GetEntities())
        {
            var path = e.moveAlongPath.Path;
            var pathIndex = e.pathPointIndex.Value;
            if (e.isMoveComplete || pathIndex == 0)
            {
                if (path != null && pathIndex < path.Length - 1)
                {
                    var currentPathIndex = pathIndex + 1;
                    e.ReplacePathPointIndex(currentPathIndex);
                    e.ReplaceMoveTargetPosition(path[currentPathIndex]);
                    e.isMoveComplete = false;
                }
                else
                {
                    e.RemovePathPointIndex();
                    e.RemoveMoveAlongPath();
                }
            }
        }
    }
}