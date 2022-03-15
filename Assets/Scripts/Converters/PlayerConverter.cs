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
            entity.isMoveCommandListener = true;
            entity.isAlignToMoveDirection = true;
        }
    }
}