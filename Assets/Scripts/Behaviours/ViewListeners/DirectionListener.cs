using Entitas;
using UnityEngine;

public class DirectionListener : MonoBehaviour, IEventListener, IDirectionListener
{
    private GameEntity _entity;
    
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddDirectionListener(this);

        if (_entity.hasDirection)
            OnDirection(_entity, _entity.direction.Value);
    }

    public void UnregisterListeners(IEntity with)
    {
        _entity.RemoveDirectionListener(this);
    }
    
    public void OnDirection(GameEntity entity, float angle)
    {
        var ang = entity.direction.Value;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.up);
    }
}