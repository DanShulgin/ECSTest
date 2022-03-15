using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;

    private void Awake()
    {
        var contexts = Contexts.sharedInstance;
        
        _systems = new Feature("Systems")
            .Add(new InputSystems(contexts))
            .Add(new MovementSystems(contexts))
            .Add(new ViewSystems(contexts));
        
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}