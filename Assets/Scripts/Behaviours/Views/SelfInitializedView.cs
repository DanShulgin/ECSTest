using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class SelfInitializedView : View
{
    protected void Awake()
    {
        Entity = Contexts.sharedInstance.game.CreateEntity();
        gameObject.Link(Entity);
        Initialize();
        RegisterListeners();
    }

    private void Start()
    {
        LateInitialize();
    }

    protected virtual void Initialize()
    {
        Entity.AddView(gameObject);
        Entity.AddPosition(transform.position);
        Entity.AddDirection(transform.rotation.eulerAngles.y);
    }

    protected virtual void LateInitialize() { }

    private void OnDestroy()
    {
        UnregisterListeners();
    }

    private void RegisterListeners()
    {
        foreach (var listener in GetComponents<IEventListener>())
        {
            listener.RegisterListeners(Entity);
        }
    }
    
    private void UnregisterListeners()
    {
        foreach (var listener in GetComponents<IEventListener>())
        {
            listener.UnregisterListeners(Entity);
        }
    }
}