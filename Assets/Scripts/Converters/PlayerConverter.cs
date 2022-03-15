using UnityEngine;
using UnityEngine.Serialization;

namespace Converters
{
    public class PlayerConverter : GameObjectToEntityConverter
    {
        [SerializeField] private Animator animator;
        
        protected override void Convert(GameEntity entity)
        {
            base.Convert(entity);
            entity.isPlayer = true;
            entity.AddMove(5f, 10f);
            entity.AddVelocity(Vector3.zero);
            entity.AddStoppingDistance(0.05f);
            entity.isMoveCommandListener = true;
            entity.AddAlignToVelocity(10f);
            entity.AddAnimator(animator);
        }
    }
}