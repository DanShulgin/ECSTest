using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public abstract class SelfInitializedView : View
{
    private void Awake()
    {
        SetupEntityComponents();
    }

    protected virtual void SetupEntityComponents()
    {
        Entity = Contexts.sharedInstance.game.CreateEntity();
        gameObject.Link(Entity);
        RegisterListeners();
        Entity.AddView(gameObject);
        Entity.AddPosition(transform.position);
        Entity.AddDirection(transform.rotation.eulerAngles.y);
    }

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