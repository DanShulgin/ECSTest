using Entitas;

public interface IEventListener
{
    void RegisterListeners(IEntity entity);
    void UnregisterListeners(IEntity with);
}