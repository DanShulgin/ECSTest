using System.Collections.Generic;
using Entitas;
using Services;
using UnityEngine;

public class MoveCommandSystem : ReactiveSystem<InputEntity>
{
    readonly InputContext _inputContext;
    readonly NavMeshService _navMeshService;
    readonly IGroup<GameEntity> _moveListeners;
    
    public MoveCommandSystem(Contexts contexts, NavMeshService navMeshService) : base(contexts.input)
    {
        _inputContext = contexts.input;
        _navMeshService = navMeshService;
        _moveListeners = contexts.game.GetGroup(GameMatcher.MoveCommandListener);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        Ray ray = Camera.main.ScreenPointToRay((_inputContext.leftMouseEntity.mousePosition.position));
        if (Physics.Raycast(ray, out var hit, 100))
        {
            var targetPosition = hit.point;
            
            foreach (GameEntity e in _moveListeners)
            {
                var entityPosition = e.position.Value;
                var path = _navMeshService.CalculatePath(entityPosition, targetPosition);
                e.ReplaceMoveAlongPath(path);
                e.ReplacePathPointIndex(0);
            }
        }
    }
}