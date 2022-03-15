using Entitas;
using UnityEngine;

public class AnimatorSpeedSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _moves;
    
    private static readonly int Speed = Animator.StringToHash("Speed");

    public AnimatorSpeedSystem(Contexts contexts)
    {
        _moves = contexts.game.GetGroup(GameMatcher.AllOf(new []{GameMatcher.Animator, GameMatcher.Velocity}));
    }

    public void Execute()
    {
        foreach (GameEntity e in _moves.GetEntities())
        {
            e.animator.Value.SetFloat(Speed, e.velocity.Value.magnitude);
        }
    }
}