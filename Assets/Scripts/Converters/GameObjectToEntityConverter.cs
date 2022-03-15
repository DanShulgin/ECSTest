using System;
using Entitas.Unity;
using UnityEngine;

public class GameObjectToEntityConverter : MonoBehaviour
{
    private void Start()
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        gameObject.Link(entity);
        Convert(entity);
    }

    protected virtual void Convert(GameEntity entity)
    {
        entity.AddView(gameObject);
        entity.AddPosition(transform.position);
        entity.AddDirection(transform.rotation.eulerAngles.y);
    }
}