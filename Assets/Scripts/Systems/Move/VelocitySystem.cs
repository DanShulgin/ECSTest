using Entitas;
using UnityEngine;

public class VelocitySystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _moves;

    public VelocitySystem(Contexts contexts)
    {
        _moves = contexts.game.GetGroup(GameMatcher.Velocity);
    }

    public void Execute()
    {
        foreach (GameEntity e in _moves.GetEntities())
        {
            Vector3 newPosition = e.position.Value + e.velocity.Value * Time.deltaTime;
            e.ReplacePosition(newPosition);
        }
    }
}