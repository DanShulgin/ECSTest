using UnityEngine;
using Entitas;
using Entitas.Unity;
using System.Collections.Generic;

public class InstantiatePrefabSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public InstantiatePrefabSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Prefab);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPrefab;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameObject = Object.Instantiate(entity.prefab.Value);
            entity.AddView(gameObject);
            gameObject.Link(entity);

            if(entity.hasInitialPosition)
            {
                gameObject.transform.position = entity.initialPosition.Value;
            }
        }
    }
}