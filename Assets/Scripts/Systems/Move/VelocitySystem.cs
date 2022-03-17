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
        foreach (var e in _moves.GetEntities())
        {
            var newPosition = e.position.Value + e.velocity.Direction * e.velocity.Magnitude * Time.deltaTime;
            e.ReplacePosition(newPosition);
        }
    }
}