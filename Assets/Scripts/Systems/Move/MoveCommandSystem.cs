using System.Collections.Generic;
using Entitas;
using Services;
using UnityEngine;

public class MoveCommandSystem : ReactiveSystem<InputEntity>
{
    readonly InputContext _inputContext;
    readonly INavMeshService _navMeshService;
    readonly IGroup<GameEntity> _moveListeners;
    
    public MoveCommandSystem(Contexts contexts, INavMeshService navMeshService) : base(contexts.input)
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
        var ray = Camera.main.ScreenPointToRay((_inputContext.leftMouseEntity.mousePosition.position));
        //TODO add raycast layer with di
        if (!Physics.Raycast(ray, out var hit, 100)) return;
        var targetPosition = hit.point;
            
        foreach (var e in _moveListeners)
        {
            var entityPosition = e.position.Value;
            var path = _navMeshService.CalculatePath(entityPosition, targetPosition);
                
            if(path == null) continue;
                
            e.ReplaceMoveAlongPath(path);
            e.ReplacePathPointIndex(0);
        }
    }
}