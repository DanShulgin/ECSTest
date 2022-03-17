using System.Collections.Generic;
using Entitas;

public class MoveAlongPathSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public MoveAlongPathSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveComplete.Added(), GameMatcher.MoveAlongPath.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMoveAlongPath && entity.hasPathPointIndex;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var path = e.moveAlongPath.Path;
            var pathIndex = e.pathPointIndex.Value;
            if (e.isMoveComplete || pathIndex == 0)
            {
                if (pathIndex < path.Length - 1)
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