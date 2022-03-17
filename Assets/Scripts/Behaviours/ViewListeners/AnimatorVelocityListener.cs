using Entitas;
using UnityEngine;

namespace Behaviours.ViewListeners
{
    public class AnimatorVelocityListener : MonoBehaviour, IEventListener, IVelocityListener
    {
        [SerializeField] private Animator animator;
        
        private GameEntity _entity;
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        
        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.AddVelocityListener(this);

            if (_entity.hasDirection)
                OnVelocity(_entity, _entity.velocity.Value);
        }

        public void UnregisterListeners(IEntity with)
        {
            _entity.RemoveVelocityListener(this);
        }
    
        public void OnVelocity(GameEntity entity, Vector3 velocity)
        {
            animator.SetFloat(Speed, entity.velocity.Value.magnitude);
        }
    }
}