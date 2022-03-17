using Entitas;
using UnityEngine;

public class PositionListener : MonoBehaviour, IEventListener, IPositionListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddPositionListener(this);

        if (_entity.hasPosition)
            OnPosition(_entity, _entity.position.Value);
    }

    public void UnregisterListeners(IEntity with)
    {
        _entity.RemovePositionListener(this);
    }

    public void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.position = value;
    }
}