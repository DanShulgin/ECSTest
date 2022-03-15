using UnityEngine;

namespace Converters
{
    public class PlayerConverter : GameObjectToEntityConverter
    {
        protected override void Convert(GameEntity entity)
        {
            base.Convert(entity);
            entity.isPlayer = true;
            entity.AddMove(5f);
            entity.AddStoppingDistance(0.05f);
            entity.isMoveCommandListener = true;
            entity.AddAlignToVelocity(10f);
        }
    }
}