using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Zenject;

public class MainBootstrap : ITickable, ILateTickable, IFixedTickable, IInitializable
{
    private readonly Contexts _contexts;
    private readonly Feature _systems;
    private readonly List<ILateSystem> _late = new List<ILateSystem>();
    private readonly List<IFixedSystem> _fixed = new List<IFixedSystem>();
    private bool _isInitialized;
    private bool _isPaused;
    

    public MainBootstrap(
        Contexts contexts,
        List<ISystem> systems)
    {
        _contexts = contexts;
        _systems = new Feature($"Bootstrap");
        for (var i = 0; i < systems.Count; i++)
        {
            var system = systems[i];
            _systems.Add(system);
            switch (system)
            {
                case ILateSystem late:
                    _late.Add(late);
                    break;
                case IFixedSystem @fixed:
                    _fixed.Add(@fixed);
                    break;
            }
        }
    }

    public void Initialize()
    {
        if (_isInitialized)
            throw new Exception("[MainBootstrap] Bootstrap already is initialized");

        _systems.Initialize();
        _isInitialized = true;
    }

    public void Tick()
    {
        if (_isPaused)
            return;

        _systems.Execute();
    }

    public void FixedTick()
    {
        if (_isPaused)
            return;

        foreach (IFixedSystem t in _fixed)
            t.Fixed();
    }

    public void LateTick()
    {
        if (_isPaused)
            return;

        for (var i = 0; i < _late.Count; i++)
            _late[i].Late();

        _systems.Cleanup();
    }
    
    public void Pause(bool isPaused) => _isPaused = isPaused;
}

public interface ILateSystem
{
    void Late();
}
public interface IFixedSystem
{
    void Fixed();
}