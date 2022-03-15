using Services;

public class MovementSystems : Feature
{
    public MovementSystems(Contexts contexts) : base("Movement Systems")
    {
        Add(new MoveCommandSystem(contexts, new NavMeshService()));
        Add(new MoveToTargetPositionSystem(contexts));
        Add(new MoveAlongPathSystem(contexts));
    }
}